using COeX_India.Data;
using COeX_India.Helper;
using COeX_India.Models;
using Microsoft.EntityFrameworkCore;

namespace COeX_India.Repositories
{
    public interface IActivityRepo
    {
        public Task<Task> ExecuteCronJob();
    }
    public class ActivityRepo:IActivityRepo
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;
        public ActivityRepo(IConfiguration config, ApplicationDbContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        public async Task<Task> ExecuteCronJob()
        {
            try
            {
                string logMsg = $"{Environment.NewLine}Activity Cron job started at : {DateTime.UtcNow}";
                Console.WriteLine(logMsg);

                var mines = await _dbContext.Mines.Where(m => (m.TriggerYield - m.CurrYield) / m.YieldPerDay == 2).ToListAsync();
                List<Requests> requestsList= new List<Requests>();

                foreach (var mine in mines)
                {
                    var existingRequest = await _dbContext.Requests.FirstOrDefaultAsync(r => r.MineId == mine.Id);
                    if(existingRequest != null)
                    {
                        continue;
                    }

                    DataHelper dh = new DataHelper();
                    List<SqlPara> paras = new List<SqlPara>();
                    paras.Add(new SqlPara("@MineId", mine.Id));
                    paras.Add(new SqlPara("@Lat", mine.latitude));
                    paras.Add(new SqlPara("@Long", mine.longitude));
                    paras.Add(new SqlPara("@p_ReturnValue", 0, System.Data.ParameterDirection.InputOutput));

                    string sqlExp = @"
Select Top (1) R.*, RailwayStations.Dist
from RailwayStations R
outer apply ( Select ((@Lat- R.latitude)*(@Lat- R.latitude) + (@Long-R.longitude)*(@Long- R.longitude)) 
as Dist from RailwayStations where RailwayStations.Id= R.Id) 
as RailwayStations
where RailwayStations.Dist< 60000 and R.Availability>0
order by RailwayStations.Dist
";
                    // if closestStations is 0 then double the radius every time
                    // 2 days should not be hardcoded
                    dh.Select(sqlExp, paras);
                    var closestStations= CommonHelper.MapTableToModel<Activity>(dh.dataSet.Tables[0]);
                    Requests request = new Requests();
                    request.MineId = mine.Id;
                    request.RailwayStationId = closestStations[0].Id;
                    request.Message = $"Mine {mine.Name} is expected to reach {mine.TriggerYield} ammount in 2 days, and is expected to charter a rake";
                    request.ExpectedToCallIn = "2 Days";
                    request.InsertedAt = DateTime.UtcNow;
                    requestsList.Add(request);
                }

                await _dbContext.AddRangeAsync(requestsList);
                await _dbContext.SaveChangesAsync();    


                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}

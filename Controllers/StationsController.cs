using Azure.Core;
using COeX_India.Data;
using COeX_India.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace COeX_India.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StationsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StationsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetMyRoutes")]
        [Authorize]

        public async Task<ActionResult> GetMyCutiees()
        {
            try
            {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                var claimStationId = claimsIdentity.FindFirst("StationId")?.Value;
                var TokenStationId = 0;
                int.TryParse(claimStationId, out TokenStationId);
                Console.WriteLine(TokenStationId);
                var myRoutesQuery = from rs in _dbContext.RailwayStations
                                    join r in _dbContext.Requests on rs.Id equals r.RailwayStationId into Alia
                                    from al in Alia.DefaultIfEmpty()
                                    join m in _dbContext.Mines on al.MineId equals m.Id into Alia1
                                    from al1 in Alia1.DefaultIfEmpty()
                                    where al.RailwayStationId == TokenStationId
                                    select new
                                    {
                                        al.Id,
                                        MineId = al.MineId,
                                        al.RailwayStationId,
                                        al1.Name,
                                        destinationLat = al1.latitude,
                                        destinationLong = al1.longitude,
                                        al.Message,
                                        al.ExpectedToCallIn
                                    };

                var myRoutesList = await myRoutesQuery.ToListAsync();
                Console.WriteLine("count ------>" + myRoutesList.Count());
                return Ok(myRoutesList);
            }
            catch (Exception ex)
            {
                //ProblemDetails problem = await CommonHelper.TakeReqActionOnException(ex, Request.Path.Value);
                return Problem(ex.Message);
            }

        }
    }
}

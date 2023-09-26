using COeX_India.Repositories;
using Quartz;

namespace COeX_India.Models
{
    public class ActivityJob: IJob
    {
        private readonly IActivityRepo _activityRepo;

        public ActivityJob(IActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
            Console.WriteLine("Hello From The outside");
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello");
            Task response = _activityRepo.ExecuteCronJob();
            return response;
        }
    }
}

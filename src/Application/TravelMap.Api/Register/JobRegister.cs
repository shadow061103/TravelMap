using Hangfire.Common;
using Hangfire;
using System.Runtime.InteropServices;
using TravelMap.Core.Config;
using TravelMap.Api.Filters;
using TravelMap.Api.Jobs.Interfaces;
using Hangfire.Server;

namespace TravelMap.Api.Register
{
    public static class JobRegister
    {
        public static void SetJob(IConfiguration Configuration)
        {
            var scheduleSettings = Configuration.GetSection("SchedulerSetting").Get<List<SchedulerConfig>>().Where(x => x.IsEnable);
            var manager = new RecurringJobManager();

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });
            GlobalJobFilters.Filters.Add(new ExceptionFilterAttribute());

            var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => p.GetInterfaces().Contains(typeof(IJob)));

            var timeZone = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
               "Taipei Standard Time" : "Asia/Taipei";

            foreach (var schedulerSetting in scheduleSettings)
            {
                var jobType = types.FirstOrDefault(x => x.Name == schedulerSetting.JobName);
                var methoods = jobType.GetMethods().FirstOrDefault();
                var methodInfo = jobType.GetMethod("RunAsync", new Type[] { typeof(object) });
                var job = new Job(jobType, methoods, (object)null);

                manager.AddOrUpdate(schedulerSetting.JobName, job, schedulerSetting.Crontab, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            }
        }
    }
}
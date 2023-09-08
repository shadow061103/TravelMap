using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.States;

namespace TravelMap.Api.Filters
{
    public class ExceptionFilterAttribute : JobFilterAttribute, IElectStateFilter
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public ExceptionFilterAttribute()
        {
        }

        public void OnStateElection(ElectStateContext context)
        {
            if (context.CandidateState is FailedState failedState)
            {
                Logger.Error($"Job {context.BackgroundJob.Job.Method} has been failed due to an exception {failedState.Exception}");
            }
        }
    }
}
using Hangfire.Server;

namespace TravelMap.Api.Jobs.Interfaces
{
    public interface IJob
    {
        Task RunAsync(PerformContext context);
    }
}
using Hangfire.Console;
using Hangfire.Server;
using System.ComponentModel;
using TravelMap.Api.Jobs.Interfaces;

namespace TravelMap.Api.Jobs
{
    public class InitCityDataJob : IJob
    {
        [DisplayName("初始化全台縣市資料")]
        public Task RunAsync(PerformContext context)
        {
            context.WriteLine("開始執行初始化縣市資料排程");

            // throw new NotImplementedException();

            context.WriteLine("結束執行初始化縣市資料排程");

            return Task.CompletedTask;
        }
    }
}
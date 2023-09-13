using Hangfire.Console;
using Hangfire.Server;
using System.ComponentModel;
using TravelMap.Api.Jobs.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Api.Jobs
{
    public class InitCityDataJob : IJob
    {
        private IInitCityDataService _initCityDataService;

        public InitCityDataJob(IInitCityDataService initCityDataService)
        {
            _initCityDataService = initCityDataService;
        }

        [DisplayName("初始化全台縣市資料")]
        public async Task RunAsync(PerformContext context)
        {
            context.WriteLine("開始執行初始化縣市資料排程");

            await _initCityDataService.CreateTaiwanCityData();

            context.WriteLine("結束執行初始化縣市資料排程");
        }
    }
}
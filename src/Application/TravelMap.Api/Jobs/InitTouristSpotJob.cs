using Hangfire.Console;
using Hangfire.Server;
using System.ComponentModel;
using TravelMap.Api.Jobs.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Api.Jobs
{
    public class InitTouristSpotJo : IJob
    {
        private readonly IToursitSpotService _toursitSpotService;

        public InitTouristSpotJo(IToursitSpotService toursitSpotService)
        {
            _toursitSpotService = toursitSpotService;
        }

        [DisplayName("初始化全台景點資料")]
        public async Task RunAsync(PerformContext context)
        {
            context.WriteLine("開始執行初始化景點資料排程");

            await _toursitSpotService.CreatetouristSpotData();

            context.WriteLine("開始執行初始化景點資料排程");
        }
    }
}
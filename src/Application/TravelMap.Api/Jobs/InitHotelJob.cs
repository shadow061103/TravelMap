using Hangfire.Console;
using Hangfire.Server;
using System.ComponentModel;
using TravelMap.Api.Jobs.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Api.Jobs
{
    public class InitHotelJob : IJob
    {
        private readonly IHotelService _hotelService;

        public InitHotelJob(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [DisplayName("初始化全台旅宿資料")]
        public async Task RunAsync(PerformContext context)
        {
            context.WriteLine("開始執行初始化全台旅宿排程");

            await _hotelService.CreateHotelData();

            context.WriteLine("結束執行初始化全台旅宿排程");
        }
    }
}
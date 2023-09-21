using Hangfire.Console;
using Hangfire.Server;
using System.ComponentModel;
using TravelMap.Api.Jobs.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Api.Jobs
{
    public class InitRestaurantJob : IJob
    {
        private readonly IRestaurantService _restaurantService;

        public InitRestaurantJob(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [DisplayName("初始化全台餐廳資料")]
        public async Task RunAsync(PerformContext context)
        {
            context.WriteLine("開始執行初始化全台餐廳排程");

            await _restaurantService.CreateRestaurantData();

            context.WriteLine("結束執行初始化全台餐廳排程");
        }
    }
}
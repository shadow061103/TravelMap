using Microsoft.Extensions.DependencyInjection;
using TravelMap.Service.Implements;
using TravelMap.Service.Interfaces;

namespace TravelMap.Service.Register
{
    public static class ServiceRegister
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IInitCityDataService, InitCityDataService>();
            services.AddScoped<IToursitSpotService, ToursitSpotService>();
        }
    }
}
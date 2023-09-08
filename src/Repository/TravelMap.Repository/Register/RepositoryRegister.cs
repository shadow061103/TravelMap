using TravelMap.Repository.Implements;
using TravelMap.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TravelMap.Repository.Register
{
    public static class RepositoryRegister
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepositroy, TokenRepositroy>();
        }
    }
}
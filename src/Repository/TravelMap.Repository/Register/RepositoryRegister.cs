using TravelMap.Repository.Implements;
using TravelMap.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TravelMap.Repository.Helper;
using TravelMap.Repository.Decorators;

namespace TravelMap.Repository.Register
{
    public static class RepositoryRegister
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddSingleton<IMongoHelper, MongoHelper>();

            services.AddScoped<ITokenRepositroy, TokenRepositroy>()
                .Decorate<ITokenRepositroy, CacheTokenRepositroy>();

            services.AddScoped<ICityRepository, CityRepository>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TravelMap.Core.RedisCache.Impl;

namespace TravelMap.Core.RedisCache.Register
{
    public static class RedisCacheRegister
    {
        public static void RegisterRedis(this IServiceCollection services, string redisUrl)
        {
            services.AddSingleton((context) => { return ConnectionMultiplexer.Connect(redisUrl); });
            services.AddSingleton<ICache>((context) =>
            {
                var connect = context.GetService<ConnectionMultiplexer>();
                return new RedisCacheService(connect);
            });
        }
    }
}
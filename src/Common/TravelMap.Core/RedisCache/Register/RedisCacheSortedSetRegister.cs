using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TravelMap.Core.RedisCache.Impl;

namespace TravelMap.Core.RedisCache.Register
{
    public static class RedisCacheSortedSetRegister
    {
        public static void RegisterRedisSortedSet(this IServiceCollection services, string redisUrl)
        {
            services.AddSingleton((context) => { return ConnectionMultiplexer.Connect(redisUrl); });
            services.AddSingleton<IRedisCacheSortedSet>((context) =>
            {
                var connect = context.GetService<ConnectionMultiplexer>();
                return new RedisCacheService(connect);
            });
        }
    }
}
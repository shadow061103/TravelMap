using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TravelMap.Core.RedisCache.Impl;

namespace TravelMap.Core.RedisCache.Register
{
    public static class RedisCacheLinkListRegister
    {
        public static void RegisterRedisLink(this IServiceCollection services, string redisUrl)
        {
            services.AddSingleton((context) => { return ConnectionMultiplexer.Connect(redisUrl); });
            services.AddSingleton<ICacheLinkList>((context) =>
            {
                var connect = context.GetService<ConnectionMultiplexer>();
                return new RedisCacheService(connect);
            });
        }
    }
}
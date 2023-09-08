using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMap.Core.Constants;
using TravelMap.Core.RedisCache;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Decorators
{
    public class CacheTokenRepositroy : ITokenRepositroy
    {
        private readonly ITokenRepositroy _tokenRepositroy;

        private ICache _cache;

        public CacheTokenRepositroy(ITokenRepositroy tokenRepositroy,
            ICache cache)
        {
            _tokenRepositroy = tokenRepositroy;
            _cache = cache;
        }

        public async Task<AccessTokenVo> GetAccessToken()
        {
            var cacheKey = CacheKey.Token;

            if (await _cache.IsKeyExist(cacheKey))
            {
                return await _cache.GetObjectAsync<AccessTokenVo>(cacheKey);
            }

            var accessToken = await _tokenRepositroy.GetAccessToken();

            //每6小時重新取一次 系統預設24小時才過期
            await _cache.SetCacheAsync(cacheKey, accessToken, TimeSpan.FromHours(6));

            return accessToken;
        }
    }
}
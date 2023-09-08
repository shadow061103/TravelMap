using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelMap.Core.RedisCache
{
    public interface ICache
    {
        /// <summary>
        /// 鍵值是否存在
        /// </summary>
        /// <param name="hashKey">Key</param>
        /// <returns></returns>
        ValueTask<bool> IsKeyExist(string hashKey);

        /// <summary>
        /// 寫入Cache 有時效性
        /// </summary>
        /// <param name="hashKey">key</param>
        /// <param name="hour">時</param>
        /// <param name="minute">分</param>
        /// <param name="second">秒</param>
        /// <param name="json">value</param>
        /// <returns></returns>
        ValueTask<bool> SetExpiredKeyAsync(string hashKey, int hour, int minute, int second, string json);

        /// <summary>
        /// 取得Cache內容
        /// </summary>
        /// <returns></returns>
        ValueTask<T> GetObjectAsync<T>(string key);

        /// <summary>
        /// 寫入Cache 有時效性
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expiry">當CacheType = Memory，且expiry = null，預設為1分鐘過期;
        /// 當CacheType = Redis，且expiry = null，該key則永久有效。</param>
        /// <returns></returns>
        ValueTask<bool> SetCacheAsync<T>(string key, T obj, TimeSpan? expiry = null);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ValueTask<bool> RemoveCacheAsync(string key);

        /// <summary>
        /// 對 key 的數值加減
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ValueTask<long> StringIncrementAsync(string key, long value = 1);
    }
}
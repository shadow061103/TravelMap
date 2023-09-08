namespace TravelMap.Core.RedisCache
{
    public interface ICacheLinkList
    {
        /// <summary>
        /// left push array
        /// </summary>
        /// <param name="key"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        ValueTask<long> LPushListAsync(string key, IEnumerable<string> objs);

        /// <summary>
        /// right push array
        /// </summary>
        /// <param name="key"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        ValueTask<long> RPushListAsync(string key, IEnumerable<string> objs);

        /// <summary>
        /// push String
        /// </summary>
        /// <param name="key"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        ValueTask<long> LPushAsync(string key, string str);

        /// <summary>
        /// right push String
        /// </summary>
        /// <param name="key"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        ValueTask<long> RPushAsync(string key, string str);

        /// <summary>
        /// pop String
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ValueTask<string> LPopAsync(string key);

        /// <summary>
        /// right pop String
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ValueTask<string> RPopAsync(string key);

        /// <summary>
        /// get array Length
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ValueTask<long> LLengthAsync(string key);

        /// <summary>
        /// set expired
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiredTime"></param>
        /// <returns></returns>
        ValueTask<bool> SetKeyExpiredAsync(string key, DateTime? expiredTime);

        /// <summary>
        /// set expired
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expiredTime"></param>
        /// <returns></returns>
        ValueTask<bool> SetKeyExpiredAsync(string key, TimeSpan? expiredTime);

        /// <summary>
        /// remove cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ValueTask<bool> RemoveCacheAsync(string key);
    }
}
using StackExchange.Redis;
using System.Text.Json;

namespace TravelMap.Core.RedisCache.Impl

{
    public class RedisCacheService : ICache, ICacheLinkList, IRedisCacheSortedSet
    {
        private readonly ConnectionMultiplexer _redisConn;

        public RedisCacheService(ConnectionMultiplexer redisConn)
        {
            _redisConn = redisConn ?? throw new ArgumentNullException(nameof(redisConn));
        }

        public async ValueTask<T> GetObjectAsync<T>(string key)
        {
            var db = _redisConn.GetDatabase();
            var value = await db.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return default;

            return JsonSerializer.Deserialize<T>(value.ToString());
        }

        public async ValueTask<bool> IsKeyExist(string hashKey)
        {
            var db = _redisConn.GetDatabase();
            return await db.KeyExistsAsync(hashKey);
        }

        public async ValueTask<long> LLengthAsync(string key)
        {
            var db = _redisConn.GetDatabase();
            return await db.ListLengthAsync(key);
        }

        public async ValueTask<string> LPopAsync(string key)
        {
            var db = _redisConn.GetDatabase();
            return await db.ListLeftPopAsync(key);
        }

        public async ValueTask<long> LPushAsync(string key, string str)
        {
            var db = _redisConn.GetDatabase();
            return await db.ListLeftPushAsync(key, str);
        }

        public async ValueTask<long> LPushListAsync(string key, IEnumerable<string> objs)
        {
            var redisValues = Array.ConvertAll(objs.ToArray(), item => (RedisValue)item);
            var db = _redisConn.GetDatabase();
            return await db.ListLeftPushAsync(key, redisValues);
        }

        public async ValueTask<bool> RemoveCacheAsync(string key)
        {
            var db = _redisConn.GetDatabase();
            return await db.KeyDeleteAsync(key);
        }

        public async ValueTask<bool> SetCacheAsync<T>(string key, T obj, TimeSpan? expiry = null)
        {
            var db = _redisConn.GetDatabase();
            var json = JsonSerializer.Serialize(obj);
            return await db.StringSetAsync(key, json, expiry);
        }

        public async ValueTask<bool> SetExpiredKeyAsync(string hashKey, int hour, int minute, int second, string json)
        {
            var db = _redisConn.GetDatabase();
            return await db.StringSetAsync(hashKey, json, new TimeSpan(hour, minute, second));
        }

        public async ValueTask<bool> SetKeyExpiredAsync(string key, DateTime? expiredTime)
        {
            var db = _redisConn.GetDatabase();
            if (expiredTime == null)
                expiredTime = DateTime.UtcNow.AddMinutes(8);
            expiredTime = DateTime.SpecifyKind((DateTime)expiredTime, DateTimeKind.Local);
            return await db.KeyExpireAsync(key, expiredTime);
        }

        public async ValueTask<bool> SetKeyExpiredAsync(string key, TimeSpan? expiredTime)
        {
            var db = _redisConn.GetDatabase();
            if (expiredTime == null)
                expiredTime = new TimeSpan(0, 8, 0);
            return await db.KeyExpireAsync(key, expiredTime);
        }

        public async ValueTask<bool> AddSortedSetMemberAsync(string key, string member, double score, CommandFlags flags = CommandFlags.None)
        {
            var db = _redisConn.GetDatabase();
            return await db.SortedSetAddAsync(key, member, score, flags);
        }

        public async ValueTask<IEnumerable<string>> GetSortedSetMembersAsync(string key, long start, long stop)
        {
            var db = _redisConn.GetDatabase();
            var members = await db.SortedSetRangeByRankWithScoresAsync(key, start, stop);

            if (members == null || !members.Any())
                return default;

            return members.Select(member => member.Element.ToString());
        }

        public async ValueTask<IEnumerable<string>> GetSortedSetMembersByScoreAsync(string key, double startScore, double stopScore)
        {
            var db = _redisConn.GetDatabase();
            var members = await db.SortedSetRangeByScoreWithScoresAsync(key, startScore, stopScore);

            if (members == null || !members.Any())
                return default;

            return members.Select(member => member.Element.ToString());
        }

        public async ValueTask<bool> RemoveSortedSetMemberAsync(string key, string member)
        {
            var db = _redisConn.GetDatabase();
            return await db.SortedSetRemoveAsync(key, member);
        }

        public async ValueTask<long> RemoveSortedSetMembersByScoreAsync(string key, long start, long stop)
        {
            var db = _redisConn.GetDatabase();
            return await db.SortedSetRemoveRangeByScoreAsync(key, start, stop);
        }

        public async ValueTask<long> RPushListAsync(string key, IEnumerable<string> objs)
        {
            var redisValues = Array.ConvertAll(objs.ToArray(), item => (RedisValue)item);
            var db = _redisConn.GetDatabase();
            return await db.ListRightPushAsync(key, redisValues);
        }

        public async ValueTask<long> RPushAsync(string key, string str)
        {
            var db = _redisConn.GetDatabase();
            return await db.ListRightPushAsync(key, str);
        }

        public async ValueTask<string> RPopAsync(string key)
        {
            var db = _redisConn.GetDatabase();
            return await db.ListRightPopAsync(key);
        }

        public async ValueTask<long> StringIncrementAsync(string key, long value = 1)
        {
            var db = _redisConn.GetDatabase();
            return await db.StringIncrementAsync(key, value);
        }
    }
}
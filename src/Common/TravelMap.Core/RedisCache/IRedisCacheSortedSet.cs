using StackExchange.Redis;

namespace TravelMap.Core.RedisCache
{
    public interface IRedisCacheSortedSet
    {
        /// <summary>
        /// add sorted set member
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="score"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        ValueTask<bool> AddSortedSetMemberAsync(string key, string member, double score, CommandFlags flags = CommandFlags.None);

        /// <summary>
        /// get sorted set member
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        ValueTask<IEnumerable<string>> GetSortedSetMembersAsync(string key, long start, long stop);

        /// <summary>
        /// get sorted set member by score
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startScore">The minimum score to filter by.</param>
        /// <param name="stopScore">The minimum score to filter by.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<string>> GetSortedSetMembersByScoreAsync(string key, double startScore, double stopScore);

        /// <summary>
        /// remove sorted set member
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        ValueTask<bool> RemoveSortedSetMemberAsync(string key, string member);

        /// <summary>
        /// remove sorted set members by score range
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        ValueTask<long> RemoveSortedSetMembersByScoreAsync(string key, long start, long stop);
    }
}
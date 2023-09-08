using TravelMap.Repository.Model;

namespace TravelMap.Repository.Interfaces
{
    public interface ITokenRepositroy
    {
        /// <summary>
        /// 取得access token
        /// </summary>
        /// <returns></returns>
        Task<AccessTokenVo> GetAccessToken();

        Task<ApiKeyVo> GetApiKey();
    }
}
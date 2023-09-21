using TravelMap.Repository.Model;

namespace TravelMap.Repository.Interfaces
{
    public interface ITouristSpotRepository
    {
        Task<IEnumerable<TourisSpotApiModel>> GetTouristSpotData(string accessToken, string city);

        Task AddTouristSpotData(IEnumerable<TourisSpotVo> spots);

        Task<IEnumerable<TourisSpotVo>> FindNearTourist(double latitude, double longitude);
    }
}
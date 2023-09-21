using TravelMap.Repository.Model;

namespace TravelMap.Repository.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<RestaurantApiModel>> GetRestaurantDataByCity(string accessToken, string city);

        Task AddrestaurantData(IEnumerable<RestaurantVo> restaurants);
    }
}
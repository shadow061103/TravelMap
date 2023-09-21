using TravelMap.Repository.Model;

namespace TravelMap.Repository.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<HotelApiModel>> GetHotelDataByCity(string accessToken, string city);

        Task AddHotelData(IEnumerable<HotelVo> hotels);
    }
}
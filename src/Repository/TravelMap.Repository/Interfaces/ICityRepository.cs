using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityApiModel>> GetTaiwanCityData(string accessToken);

        Task AddCityData(IEnumerable<CityVo> cities);

        Task<IEnumerable<CityVo>> GetCityData();
    }
}
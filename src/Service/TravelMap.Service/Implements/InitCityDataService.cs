using AutoMapper;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;
using TravelMap.Service.Interfaces;

namespace TravelMap.Service.Implements
{
    public class InitCityDataService : IInitCityDataService
    {
        private readonly ITokenRepositroy _tokenRepositroy;

        private readonly ICityRepository _cityRepository;

        private readonly IMapper _mapper;

        public InitCityDataService(ITokenRepositroy tokenRepositroy,
            ICityRepository cityRepository,
            IMapper mapper)
        {
            _tokenRepositroy = tokenRepositroy;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task CreateTaiwanCityData()
        {
            var token = await _tokenRepositroy.GetAccessToken();

            var cityData = await _cityRepository.GetTaiwanCityData(token.AccessToken);

            await _cityRepository.AddCityData(_mapper.Map<IEnumerable<CityVo>>(cityData));
        }
    }
}
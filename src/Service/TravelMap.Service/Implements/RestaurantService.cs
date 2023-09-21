using AutoMapper;
using TravelMap.Repository.Implements;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;
using TravelMap.Service.Interfaces;

namespace TravelMap.Service.Implements
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        private readonly ICityRepository _cityRepository;

        private readonly ITokenRepositroy _tokenRepositroy;

        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository,
            ICityRepository cityRepository,
            ITokenRepositroy tokenRepositroy,
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _cityRepository = cityRepository;
            _tokenRepositroy = tokenRepositroy;
            _mapper = mapper;
        }

        public async Task CreateRestaurantData()
        {
            var token = await _tokenRepositroy.GetAccessToken();

            var cities = await _cityRepository.GetCityData();

            foreach (var item in cities)
            {
                var restaurants = await _restaurantRepository.GetRestaurantDataByCity(token.AccessToken, item.City);

                if (restaurants.Any() == false)
                    continue;

                var restaurantVos = _mapper.Map<List<RestaurantVo>>(restaurants);

                restaurantVos.ForEach(c =>
                {
                    c.City = item.City;
                    c.CityName = item.CityName;
                });

                await _restaurantRepository.AddrestaurantData(restaurantVos);
            }
        }
    }
}
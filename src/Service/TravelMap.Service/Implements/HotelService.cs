using AutoMapper;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;
using TravelMap.Service.Interfaces;

namespace TravelMap.Service.Implements
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        private readonly ICityRepository _cityRepository;

        private readonly ITokenRepositroy _tokenRepositroy;

        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository,
            ICityRepository cityRepository,
            ITokenRepositroy tokenRepositroy,
            IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _cityRepository = cityRepository;
            _tokenRepositroy = tokenRepositroy;
            _mapper = mapper;
        }

        public async Task CreateHotelData()
        {
            var token = await _tokenRepositroy.GetAccessToken();

            var cities = await _cityRepository.GetCityData();

            foreach (var item in cities)
            {
                var hotels = await _hotelRepository.GetHotelDataByCity(token.AccessToken, item.City);

                if (hotels.Any() == false)
                    continue;

                var hotelVos = _mapper.Map<List<HotelVo>>(hotels);

                hotelVos.ForEach(c =>
                {
                    c.City = item.City;
                    c.CityName = item.CityName;
                });

                await _hotelRepository.AddHotelData(hotelVos);
            }
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;
using TravelMap.Service.Interfaces;

namespace TravelMap.Service.Implements
{
    public class ToursitSpotService : IToursitSpotService
    {
        private readonly ITouristSpotRepository _touristSpotRepository;

        private readonly ICityRepository _cityRepository;

        private readonly ITokenRepositroy _tokenRepositroy;

        private readonly IMapper _mapper;

        public ToursitSpotService(ITouristSpotRepository touristSpotRepository,
            ICityRepository cityRepository,
            ITokenRepositroy tokenRepositroy,
            IMapper mapper)
        {
            _touristSpotRepository = touristSpotRepository;
            _cityRepository = cityRepository;
            _tokenRepositroy = tokenRepositroy;
            _mapper = mapper;
        }

        public async Task CreatetouristSpotData()
        {
            var token = await _tokenRepositroy.GetAccessToken();

            var cities = await _cityRepository.GetCityData();

            foreach (var item in cities)
            {
                var spots = await _touristSpotRepository.GetTouristSpotData(token.AccessToken, item.City);

                var spotVos = _mapper.Map<List<TourisSpotVo>>(spots);

                spotVos.ForEach(c =>
                {
                    c.City = item.City;
                });

                await _touristSpotRepository.AddTouristSpotData(spotVos);
            }
        }
    }
}
using AutoMapper;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Profiles
{
    public class TDXProfile : Profile
    {
        public TDXProfile()
        {
            CreateMap<CityApiModel, CityVo>();
        }
    }
}
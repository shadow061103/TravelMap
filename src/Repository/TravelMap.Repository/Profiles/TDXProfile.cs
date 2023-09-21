using AutoMapper;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Profiles
{
    public class TDXProfile : Profile
    {
        public TDXProfile()
        {
            CreateMap<CityApiModel, CityVo>();

            CreateMap<TourisSpotApiModel, TourisSpotVo>()
                .ForMember(d => d.SpotName, o => o.MapFrom(s => s.ScenicSpotName))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.DescriptionDetail))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(d => d.OpenTime, o => o.MapFrom(s => s.OpenTime))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.Picture.PictureUrl1))
                .ForMember(d => d.PictureDescription, o => o.MapFrom(s => s.Picture.PictureDescription1))
                .ForMember(d => d.PositionLon, o => o.MapFrom(s => s.Position.PositionLon))
                .ForMember(d => d.PositionLat, o => o.MapFrom(s => s.Position.PositionLat))
                .ForMember(d => d.Class, o => o.MapFrom(s => s.Class1))
                .ForMember(d => d.Level, o => o.MapFrom(s => s.Level))
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City));
        }
    }
}
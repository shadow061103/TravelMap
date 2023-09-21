using AutoMapper;
using MongoDB.Driver.GeoJsonObjectModel;
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
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.City))
                .ForMember(d => d.Location, o => o.MapFrom(s => GeoJson.Point(GeoJson.Geographic(s.Position.PositionLon, s.Position.PositionLat))));

            CreateMap<RestaurantApiModel, RestaurantVo>()
                .ForMember(d => d.RestaurantName, o => o.MapFrom(s => s.RestaurantName))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(d => d.OpenTime, o => o.MapFrom(s => s.OpenTime))
                .ForMember(d => d.MapUrl, o => o.MapFrom(s => s.MapUrl))
                .ForMember(d => d.Location, o => o.MapFrom(s => GeoJson.Point(GeoJson.Geographic(s.Position.PositionLon, s.Position.PositionLat))))
                .ForMember(d => d.Pictures, o => o.MapFrom<PictureResolver, PictureApiModel>(s => s.Picture));

            CreateMap<HotelApiModel, HotelVo>()
                 .ForMember(d => d.HotelName, o => o.MapFrom(s => s.HotelName))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(d => d.Class, o => o.MapFrom(s => s.Class))
                .ForMember(d => d.ServiceInfo, o => o.MapFrom(s => s.ServiceInfo))
                .ForMember(d => d.ParkingInfo, o => o.MapFrom(s => s.ParkingInfo))
                .ForMember(d => d.Location, o => o.MapFrom(s => GeoJson.Point(GeoJson.Geographic(s.Position.PositionLon, s.Position.PositionLat))))
                .ForMember(d => d.Pictures, o => o.MapFrom<PictureResolver, PictureApiModel>(s => s.Picture));

            ;
        }
    }

    public class PictureResolver : IMemberValueResolver<object, object, PictureApiModel, List<string>>
    {
        public List<string> Resolve(object source, object destination, PictureApiModel sourceMember, List<string> destMember, ResolutionContext context)
        {
            var pictures = new List<string>();

            if (!string.IsNullOrEmpty(sourceMember.PictureUrl1))
                pictures.Add(sourceMember.PictureUrl1);

            if (!string.IsNullOrEmpty(sourceMember.PictureUrl2))
                pictures.Add(sourceMember.PictureUrl2);

            if (!string.IsNullOrEmpty(sourceMember.PictureUrl3))
                pictures.Add(sourceMember.PictureUrl3);

            return pictures;
        }
    }
}
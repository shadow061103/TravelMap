using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace TravelMap.Repository.Model
{
    [BsonIgnoreExtraElements]
    public class HotelVo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("city_name")]
        public string CityName { get; set; }

        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        [BsonElement("hotel_name")]
        public string HotelName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("pictures")]
        public List<string> Pictures { get; set; }

        [BsonElement("class")]
        public string Class { get; set; }

        [BsonElement("service_info")]
        public string ServiceInfo { get; set; }

        [BsonElement("parking_info")]
        public string ParkingInfo { get; set; }
    }
}
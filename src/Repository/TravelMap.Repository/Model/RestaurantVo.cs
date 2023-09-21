using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace TravelMap.Repository.Model
{
    [BsonIgnoreExtraElements]
    public class RestaurantVo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("city_name")]
        public string CityName { get; set; }

        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        [BsonElement("restaurant_name")]
        public string RestaurantName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("open_time")]
        public string OpenTime { get; set; }

        [BsonElement("map_url")]
        public string MapUrl { get; set; }

        [BsonElement("pictures")]
        public List<string> Pictures { get; set; }
    }
}
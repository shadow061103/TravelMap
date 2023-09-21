using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace TravelMap.Repository.Model
{
    [BsonIgnoreExtraElements]
    public class TourisSpotVo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("spot_name")]
        public string SpotName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("open_time")]
        public string OpenTime { get; set; }

        [BsonElement("picture_url")]
        public string PictureUrl { get; set; }

        [BsonElement("picture_description")]
        public string PictureDescription { get; set; }

        [BsonElement("lon")]
        public float PositionLon { get; set; }

        [BsonElement("lat")]
        public float PositionLat { get; set; }

        [BsonElement("class")]
        public string Class { get; set; }

        [BsonElement("level")]
        public string Level { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("city_name")]
        public string CityName { get; set; }

        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }
    }
}
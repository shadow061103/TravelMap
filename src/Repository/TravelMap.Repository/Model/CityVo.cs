using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TravelMap.Repository.Model
{
    [BsonIgnoreExtraElements]
    public class CityVo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("city_name")]
        public string CityName { get; set; }

        [BsonElement("city_code")]
        public string CityCode { get; set; }
    }
}
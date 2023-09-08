using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TravelMap.Repository.Model
{
    [BsonIgnoreExtraElements]
    public class ApiKeyVo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("client_id")]
        public string ClientId { get; set; }

        [BsonElement("client_secret")]
        public string ClientSecret { get; set; }
    }
}
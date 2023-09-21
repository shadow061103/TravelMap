using Microsoft.AspNetCore.Http.Extensions;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Text.Json;
using TravelMap.Repository.Helper;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Implements
{
    public class TouristSpotRepository : ITouristSpotRepository
    {
        private readonly HttpClient _httpClient;

        private readonly IMongoHelper _mongoHelper;

        public TouristSpotRepository(IHttpClientFactory clientFactory,
            IMongoHelper mongoHelper)
        {
            _httpClient = clientFactory.CreateClient("tourist_service");
            _mongoHelper = mongoHelper;
        }

        public async Task<IEnumerable<TourisSpotApiModel>> GetTouristSpotData(string accessToken, string city)
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("authorization"))
                _httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");

            var qb = new QueryBuilder();
            qb.Add("$top", "9999");
            qb.Add("format", "JSON");

            var response = await _httpClient.GetAsync(city + qb.ToQueryString().Value);

            var responseContent = await response.Content.ReadAsStringAsync();

            var res = JsonSerializer.Deserialize<List<TourisSpotApiModel>>(responseContent);

            return res;
        }

        public async Task AddTouristSpotData(IEnumerable<TourisSpotVo> spots)
        {
            var collection = _mongoHelper.GetMongoCollection<TourisSpotVo>("tourist_spot");

            await collection.InsertManyAsync(spots);
        }

        public async Task<IEnumerable<TourisSpotVo>> FindNearTourist(double latitude, double longitude)
        {
            var collection = _mongoHelper.GetMongoCollection<TourisSpotVo>("tourist_spot");

            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));

            var builder = Builders<TourisSpotVo>.Filter;

            var filter = builder.Near(x => x.Location, point, maxDistance: 2000, minDistance: 500);

            var res = await collection.Find(filter).ToListAsync();

            return res;
        }
    }
}
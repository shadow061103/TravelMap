using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using TravelMap.Repository.Helper;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Implements
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HttpClient _httpClient;

        private readonly IMongoHelper _mongoHelper;

        public HotelRepository(IHttpClientFactory clientFactory,
            IMongoHelper mongoHelper)
        {
            _httpClient = clientFactory.CreateClient("hotel_service");
            _mongoHelper = mongoHelper;
        }

        public async Task<IEnumerable<HotelApiModel>> GetHotelDataByCity(string accessToken, string city)
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("authorization"))
                _httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");

            var qb = new QueryBuilder();
            qb.Add("$top", "9999");
            qb.Add("format", "JSON");

            var response = await _httpClient.GetAsync(city + qb.ToQueryString().Value);

            var responseContent = await response.Content.ReadAsStringAsync();

            var res = JsonSerializer.Deserialize<List<HotelApiModel>>(responseContent);

            return res;
        }

        public async Task AddHotelData(IEnumerable<HotelVo> hotels)
        {
            var collection = _mongoHelper.GetMongoCollection<HotelVo>("hotel");

            await collection.InsertManyAsync(hotels);
        }
    }
}
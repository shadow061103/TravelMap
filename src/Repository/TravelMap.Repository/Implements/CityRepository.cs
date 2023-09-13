using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using TravelMap.Repository.Helper;
using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;

namespace TravelMap.Repository.Implements
{
    public class CityRepository : ICityRepository
    {
        private readonly HttpClient _httpClient;

        private readonly IMongoHelper _mongoHelper;

        public CityRepository(IHttpClientFactory clientFactory,
            IMongoHelper mongoHelper)
        {
            _httpClient = clientFactory.CreateClient("city_serivce");
            _mongoHelper = mongoHelper;
        }

        public async Task<IEnumerable<CityApiModel>> GetTaiwanCityData(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");

            var qb = new QueryBuilder();
            qb.Add("$select", "CityName,CityCode,City");
            qb.Add("format", "JSON");

            var response = await _httpClient.GetAsync(qb.ToQueryString().Value);

            var responseContent = await response.Content.ReadAsStringAsync();

            var res = JsonSerializer.Deserialize<List<CityApiModel>>(responseContent);

            return res;
        }

        public async Task AddCityData(IEnumerable<CityVo> cities)
        {
            var collection = _mongoHelper.GetMongoCollection<CityVo>("city");

            await collection.InsertManyAsync(cities);
        }
    }
}
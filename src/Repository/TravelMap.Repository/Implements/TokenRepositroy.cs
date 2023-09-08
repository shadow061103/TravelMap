using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using TravelMap.Core.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using TravelMap.Repository.Helper;

namespace TravelMap.Repository.Implements
{
    public class TokenRepositroy : ITokenRepositroy
    {
        private readonly HttpClient _httpClient;

        private readonly IMongoHelper _mongoHelper;

        private readonly ILogger<TokenRepositroy> _logger;

        public TokenRepositroy(IHttpClientFactory clientFactory,
           IMongoHelper mongoHelper,
            ILogger<TokenRepositroy> logger)
        {
            _httpClient = clientFactory.CreateClient("token_serivce");
            _mongoHelper = mongoHelper;
            _logger = logger;
        }

        public async Task<AccessTokenVo> GetAccessToken()
        {
            var apiKey = await GetApiKey();

            HttpContent formData = new FormUrlEncodedContent(
            new List<KeyValuePair<string, string>>
                {
                            new KeyValuePair<string, string>("grant_type", "client_credentials"),
                            new KeyValuePair<string, string>("client_id",apiKey.ClientId),
                            new KeyValuePair<string, string>("client_secret", apiKey.ClientSecret),
                }
            );
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var response = await _httpClient.PostAsync("", formData);
            var responseStr = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("token response {0}", responseStr);

            var token = JsonSerializer.Deserialize<AccessTokenVo>(responseStr);

            return token;
        }

        private async Task<ApiKeyVo> GetApiKey()
        {
            var collection = _mongoHelper.GetMongoCollection<ApiKeyVo>("api_key");

            //查全部
            var res = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();

            return res;
        }
    }
}
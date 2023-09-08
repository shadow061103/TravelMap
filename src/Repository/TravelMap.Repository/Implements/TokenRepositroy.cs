using TravelMap.Repository.Interfaces;
using TravelMap.Repository.Model;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using TravelMap.Core.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TravelMap.Repository.Implements
{
    public class TokenRepositroy : ITokenRepositroy
    {
        private readonly HttpClient _httpClient;

        private readonly MongoSettingConfig _mongoSetting;

        private readonly ILogger<TokenRepositroy> _logger;

        public TokenRepositroy(IHttpClientFactory clientFactory,
            IOptions<MongoSettingConfig> options,
            ILogger<TokenRepositroy> logger)
        {
            _httpClient = clientFactory.CreateClient("token_serivce");
            _mongoSetting = options.Value;
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

        public async Task<ApiKeyVo> GetApiKey()
        {
            var client = new MongoClient(_mongoSetting.BaseUrl);
            var db = client.GetDatabase(_mongoSetting.DatabaseName);
            var collection = db.GetCollection<ApiKeyVo>("api_key");

            var res = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();

            return res;
        }
    }
}
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMap.Core.Config;

namespace TravelMap.Repository.Helper
{
    public class MongoHelper : IMongoHelper
    {
        private readonly MongoSettingConfig _mongoSetting;

        public MongoHelper(IOptions<MongoSettingConfig> options)
        {
            _mongoSetting = options.Value;
        }

        public IMongoCollection<T> GetMongoCollection<T>(string name) => GetMongoDatabase().GetCollection<T>(name);

        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_mongoSetting.BaseUrl);
            var db = client.GetDatabase(_mongoSetting.DatabaseName);
            return db;
        }
    }
}
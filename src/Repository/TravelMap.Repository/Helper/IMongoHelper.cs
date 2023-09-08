using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelMap.Repository.Helper
{
    public interface IMongoHelper
    {
        IMongoCollection<T> GetMongoCollection<T>(string name);
    }
}
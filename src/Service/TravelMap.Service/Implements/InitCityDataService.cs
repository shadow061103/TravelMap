using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMap.Repository.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Service.Implements
{
    public class InitCityDataService : IInitCityDataService
    {
        private readonly ITokenRepositroy _tokenRepositroy;

        public InitCityDataService(ITokenRepositroy tokenRepositroy)
        {
            _tokenRepositroy = tokenRepositroy;
        }

        public async Task CreateTaiwanCityData()
        {
        }
    }
}
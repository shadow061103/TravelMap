using Microsoft.AspNetCore.Mvc;
using TravelMap.Repository.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ITokenRepositroy _tokenRepositroy;

        private readonly IInitCityDataService _initCityDataService;

        private readonly IToursitSpotService _toursitSpotService;

        private readonly ITouristSpotRepository _touristSpotRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ITokenRepositroy tokenRepositroy,
            IInitCityDataService initCityDataService,
            IToursitSpotService toursitSpotService,
            ITouristSpotRepository touristSpotRepository)
        {
            _logger = logger;
            _tokenRepositroy = tokenRepositroy;
            _initCityDataService = initCityDataService;
            _toursitSpotService = toursitSpotService;
            _touristSpotRepository = touristSpotRepository;
        }

        [HttpGet("toekn")]
        public async Task<IActionResult> GetToken()
        {
            var token = await _tokenRepositroy.GetAccessToken();

            return Ok(token);
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetCity()
        {
            await _initCityDataService.CreateTaiwanCityData();

            return Ok(null);
        }

        [HttpGet("spot")]
        public async Task<IActionResult> GetSpot()
        {
            //await _toursitSpotService.CreatetouristSpotData();

            var temp = await _touristSpotRepository.FindNearTourist(25.057210, 121.535097);
            return Ok(temp);
        }
    }
}
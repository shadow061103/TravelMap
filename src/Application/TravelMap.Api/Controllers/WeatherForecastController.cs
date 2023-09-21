using Microsoft.AspNetCore.Mvc;
using TravelMap.Repository.Interfaces;
using TravelMap.Service.Interfaces;

namespace TravelMap.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ITokenRepositroy _tokenRepositroy;

        private readonly IInitCityDataService _initCityDataService;

        private readonly IToursitSpotService _toursitSpotService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ITokenRepositroy tokenRepositroy,
            IInitCityDataService initCityDataService,
            IToursitSpotService toursitSpotService)
        {
            _logger = logger;
            _tokenRepositroy = tokenRepositroy;
            _initCityDataService = initCityDataService;
            _toursitSpotService = toursitSpotService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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
            await _toursitSpotService.CreatetouristSpotData();
            return Ok(null);
        }
    }
}
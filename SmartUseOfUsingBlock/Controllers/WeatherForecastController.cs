using Microsoft.AspNetCore.Mvc;
using SmartUseOfUsingBlock.Models;
using SmartUseOfUsingBlock.Util;

namespace SmartUseOfUsingBlock.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private const string OpenWeatherApiKey = "";
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{city}")]
        public async Task<WeatherResponse?> GetCurrentWeatherAsync([FromRoute] string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={OpenWeatherApiKey}";
            var httpClient = _httpClientFactory.CreateClient();

            using var _ = _logger.TimedOperation("Weather retrieval for {0}", city);

            var weatherResponse = await httpClient.GetAsync(url);
            if(weatherResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            var weather = await weatherResponse.Content.ReadFromJsonAsync<WeatherResponse>();
            return weather;
        }
        
    }
}
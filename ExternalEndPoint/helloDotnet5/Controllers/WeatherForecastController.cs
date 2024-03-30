using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloDotnet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WhetherClient client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WhetherClient client)
        {
            _logger = logger;
            this.client = client;
        }

        [HttpGet]
        [Route("{city}")]
        public async Task<WeatherForecast> Get(string city)
        {
            var forcast = await client.GetCurrentWhetherAsync(city);
            return new WeatherForecast
            {
                Summary = forcast.weather?[0].description,
                TemperatureC = (int)forcast.main.temp,
                Date = DateTimeOffset.FromUnixTimeSeconds(forcast.dt).DateTime
            };
        }
    }
}

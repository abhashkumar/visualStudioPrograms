using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("WeatherForecaseResults")]
        public ActionResult<WeatherForecast[]> GetWeatherForecaseResults()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [ProducesResponseType(typeof(WeatherForecast[]), 200)]
        [Route("WeatherForecaseResults_")]
        public IActionResult GetWeatherForecaseResults_()
        {
            var rng = new Random();
            var content = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return Ok(content);
        }
        [HttpGet]
        [Route("WeatherForecaseResults_/{place}")]
        public IActionResult GetWeatherForecaseResults_(string place)
        {
            int result;
            if (Int32.TryParse(place, out result))
            {

            }
            var rng = new Random();
            var content = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            if (place.ToUpper().Equals("Patna".ToUpper()))
            {
                return Ok(content);
            }
            else
                return NotFound();
        }
        [HttpGet]
        [Route("WeatherForecaseResults__/{place}")]
        public IActionResult GetWeatherForecaseResults__(string place)
        {
            int result;
            if (Int32.TryParse(place, out result))
            {

            }
            var rng = new Random();
            var content = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            if (place.ToUpper().Equals("Patna".ToUpper()))
            {
                return Ok(content);
            }
            throw new ArgumentNullException("number of parameters are not present");
        }
    }
}

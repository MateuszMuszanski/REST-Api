using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _weatherForecastService.Get();
            return result;
        }

        [HttpGet("currentDay/{take}")]
        public ActionResult<IEnumerable<WeatherForecast>> Get2([FromBody] Temperature temperature, [FromRoute] int take)
        {
            if(take > 0 || temperature.Max> temperature.Min)
            {
                return BadRequest();
            }
            var result = _weatherForecastService.GetCustom(temperature.Min, temperature.Max, take);
            return Ok(result);
        }
    }
}

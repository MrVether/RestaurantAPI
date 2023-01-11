using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generator([FromQuery] int Count, [FromBody] TemperatureRequest request)
        {
            if (Count < 0 || request.Max < request.Min)
            {
                return BadRequest();
            }
            var result = _service.Get(Count, request.Min, request.Max);
            return Ok(result);
        }
    }
}



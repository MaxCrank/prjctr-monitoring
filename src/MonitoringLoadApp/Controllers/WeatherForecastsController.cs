using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringLoadApp.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMongoCollection<WeatherForecast> _mongoCollection;

        public WeatherForecastsController(IMongoCollection<WeatherForecast> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        [HttpGet("randombatch")]
        public async Task<IActionResult> Post()
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            await _mongoCollection.BulkWriteAsync(forecasts.Select(f => new InsertOneModel<WeatherForecast>(f)));

            return Ok();
        }
    }
}

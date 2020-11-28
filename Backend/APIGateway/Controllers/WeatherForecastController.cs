using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Core.Utility.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIGateway.Controllers
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
        private readonly IMemoryCachingService _cachingService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCachingService cachingService)
        {
            _logger = logger;
            _cachingService = cachingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("hello world");
            var rng = new Random();

            List<WeatherForecast> result = new List<WeatherForecast>();

            try
            {
                int a = 1;
                int b = 0;
                if (a / b == 0)
                {

                }
            }
            catch(Exception ex)
            {

            }

            var list = _cachingService.List<WeatherForecast>("data");

            if (list == null)
            {
                result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();

                _cachingService.Set(result, "data", 1);
            }
            else
            {
                result = list;
            }
            return result;
        }

        [HttpGet, Route("GetData")]
        [AllowAnonymous]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByHeader = "id")]
        public IEnumerable<WeatherForecast> GetData(int id)
        {
            _logger.LogInformation("hello world");
            var rng = new Random();

            List<WeatherForecast> result = new List<WeatherForecast>();

            try
            {
                int a = 1;
                int b = 0;
                if (a / b == 0)
                {

                }
            }
            catch (Exception ex)
            {

            }

            var list = _cachingService.List<WeatherForecast>("data");

            if (list == null)
            {
                result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();

                _cachingService.Set(result, "data", 1);
            }
            else
            {
                result = list;
            }
            return result;
        }

        [HttpGet, Route("GetData1")]
        [AllowAnonymous]
        public IEnumerable<WeatherForecast> GetData1()
        {
            _logger.LogInformation("hello world");
            var rng = new Random();

            List<WeatherForecast> result = new List<WeatherForecast>();

            try
            {
                int a = 1;
                int b = 0;
                if (a / b == 0)
                {

                }
            }
            catch (Exception ex)
            {

            }

            var list = _cachingService.List<WeatherForecast>("data");

            if (list == null)
            {
                result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();

                _cachingService.Set(result, "data", 1);
            }
            else
            {
                result = list;
            }
            return result;
        }

    }
}

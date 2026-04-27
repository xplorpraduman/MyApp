using MyApp.Interface;
using MyApp.Queries.Models;

namespace MyApp.Service
{
    public class StaticWeatherService : IWeatherService
    {
        public Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
        {
            var data = new List<WeatherForecast>
            {
            new WeatherForecast { Date = DateOnly.MinValue, TemperatureC = 25, Summary = "Sunny" }
            };

            return Task.FromResult<IEnumerable<WeatherForecast>>(data); ;
        }
    }
}


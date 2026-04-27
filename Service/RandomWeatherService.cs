using MyApp.Interface;
using MyApp.Queries.Models;

namespace MyApp.Service
{
    public class RandomWeatherService : IWeatherService
    {
        public Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
        {
            var rng = new Random();

            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.MinValue,
                TemperatureC = rng.Next(-10, 40),
                Summary = "Random"
            });

            return Task.FromResult(data);
        }
    }

}

using MyApp.Queries.Models;

namespace MyApp.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
        {
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });

            return Task.FromResult(forecasts);
        }
    }
}
using MyApp.Queries.Models;

namespace MyApp.Interface
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherAsync();
    }
}

using MyApp.Queries.Models;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync();
}
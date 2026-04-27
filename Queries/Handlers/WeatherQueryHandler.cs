using MediatR;
using MyApp.Queries;
using MyApp.Queries.Models;

public class WeatherQueryHandler(IWeatherForecastRepository repository) : IRequestHandler<WeatherQuery, IEnumerable<WeatherForecast>>
{
    private readonly IWeatherForecastRepository _repository = repository;

    public async Task<IEnumerable<WeatherForecast>> Handle(WeatherQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetForecastsAsync();
    }
}
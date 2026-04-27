using MediatR;
using MyApp.Queries.Models;

namespace MyApp.Queries
{
    public record WeatherQuery() : IRequest<IEnumerable<WeatherForecast>>;
}

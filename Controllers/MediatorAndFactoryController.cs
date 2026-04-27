using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Factory;
using MyApp.Queries;
using MyApp.Queries.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediatorAndFactoryController(ILogger<MediatorAndFactoryController> _logger, IMediator _mediator, IWeatherServiceFactory _factory) : ControllerBase
    {
        /// <summary>
        /// Mediator Pattern 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("/Mediator")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _mediator.Send(new WeatherQuery());
        }

        /// <summary>
        /// Factory Pattern
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/factory")]
        public async Task<IEnumerable<WeatherForecast>> Get([FromQuery] string type)
        {
            var service = _factory.Create(type);
            return await service.GetWeatherAsync();
        }
    }
}

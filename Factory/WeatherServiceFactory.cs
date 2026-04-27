using MyApp.Interface;
using MyApp.Service;

namespace MyApp.Factory
{
    public class WeatherServiceFactory : IWeatherServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public WeatherServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IWeatherService Create(string type)
        {
            return type?.ToLower() switch
            {
                "random" => _serviceProvider.GetRequiredService<RandomWeatherService>(),
                "static" => _serviceProvider.GetRequiredService<StaticWeatherService>(),
                _ => throw new ArgumentException("Invalid weather type")
            };
        }
    }
}

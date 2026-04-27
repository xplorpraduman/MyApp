using MyApp.Interface;

namespace MyApp.Factory
{
    public interface IWeatherServiceFactory
    {
        IWeatherService Create(string type);

    }
}

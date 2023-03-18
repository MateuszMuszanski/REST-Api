using System.Collections.Generic;

namespace RestaurantAPI
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> GetCustom(int min, int max, int take);
    }
}
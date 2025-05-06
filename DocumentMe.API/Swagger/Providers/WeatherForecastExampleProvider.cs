using DocumentMe.API.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DocumentMe.API.Swagger.Providers
{
    public class WeatherForecastExampleProvider : IExamplesProvider<WeatherForecast>
    {
        public WeatherForecast GetExamples()
        {
            return new WeatherForecast
            {
                Date = DateOnly.Parse("2025-05-06"),
                TemperatureC = 25,
                Summary = "Partly cloudy"
            };
        }
    }
}

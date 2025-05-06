using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DocumentMe.API.Swagger.Filters
{
    public class WeatherDescriptionOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check for the POST method on WeatherForecast route
            if (context.ApiDescription.RelativePath.Equals("WeatherForecast", StringComparison.OrdinalIgnoreCase)
                && context.ApiDescription.HttpMethod?.Equals("POST", StringComparison.OrdinalIgnoreCase) == true)
            {
                operation.Summary = "Submits a new weather forecast entry";
                operation.Description =
@"Creates a new **WeatherForecast** object. The request body must include:

- **date**: The forecast date.

- **temperatureC**: The temperature in Celsius.

- **summary**: A short description of the weather.

**Example Request:**

```json
{
    ""date"": ""2025-05-06"",
    ""temperatureC"": 100,
    ""summary"": ""Sunny""
}
```";
            }
        }
    }
}

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DocumentMe.API.Swagger.Filters
{
    public class CreatedResponseLinkOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Responses.TryGetValue("201", out var response))
            {
                response.Links = new Dictionary<string, OpenApiLink>
            {
                {
                    "getForecastById",
                    new OpenApiLink
                    {
                        OperationId = "GetWeatherForecast", // must match your GET route name
                        
                        Description = "Get the created forecast by ID."
                    }
                }
            };
            }
        }
    }
}

using DocumentMe.API.Data.Abstraction;
using DocumentMe.API.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DocumentMe.API.Controllers;
/// <summary>
/// Weather Forecast Controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IRepository<WeatherForecast> _weatherForecastRepo;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IRepository<WeatherForecast> weatherForecastRepo,
        ILogger<WeatherForecastController> logger)
    {
        _weatherForecastRepo = weatherForecastRepo;
        _logger = logger;
    }


    /// <summary>
    /// Retrieves the current weather forecast for the next 5 days.
    /// </summary>
    /// <remarks>
    /// This endpoint returns a list of weather forecasts including the date,
    /// temperature in Celsius, and a short summary description.
    ///
    /// Example:
    /// 
    ///     GET /WeatherForecast
    ///
    /// Response:
    /// 
    ///     [
    ///         {
    ///             "date": "2025-05-07",
    ///             "temperatureC": 23,
    ///             "summary": "Cloudy"
    ///         },
    ///         ...
    ///     ]
    /// </remarks>
    /// <returns>
    /// A list of <see cref="WeatherForecast"/> objects representing the forecast data.
    /// </returns>
    /// <response code="200">Forecast retrieved successfully</response>
    /// <response code="500">An unexpected error occurred</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherForecastRepo.GetAll();
    }

    [HttpPost(Name = "PostWeatherForecast")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [SwaggerOperation(
     Summary = "Submits a new weather forecast entry",
     Description = "Creates a new WeatherForecast object. The data must include a date, temperature in Celsius, and a summary string."
 )]
    [SwaggerResponse(StatusCodes.Status201Created, "The weather forecast was created successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. The request body does not conform to the expected schema.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "An unexpected error occurred.")]
    public IActionResult Post([FromBody, SwaggerRequestBody("The weather forecast object to be created", Required = true)] WeatherForecast model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        // This would normally save to a database or list
        _weatherForecastRepo.Add(model); // <-- Placeholder. Replace with your actual logic.

        return CreatedAtAction(nameof(Get), new { id = 1 }, model); // Assuming you return some location for the new resource.
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
    Summary = "Updates an existing weather forecast entry.",
    Description = @"Updates the weather forecast for the given ID with new values.
**Required fields**:

- `date` (ISO 8601 format, e.g., ""2025-05-07"")

- `temperatureC` (integer)

- `summary` (short weather description)

**Example Request**:
     
PUT /WeatherForecast


    {
      ""date"": ""2025-05-07"",
      ""temperatureC"": 23,
      ""summary"": ""Cloudy""
    }

",
    OperationId = "UpdateWeatherForecast"
)]

    [SwaggerResponse(200, "The weather forecast was updated successfully.", typeof(WeatherForecast))]
    [SwaggerResponse(400, "Invalid input data. The request body does not conform to the expected schema.")]
    [SwaggerResponse(404, "The weather forecast with the specified ID was not found.")]
    [SwaggerResponse(500, "An unexpected error occurred.")]
    public IActionResult Update(int id, [FromBody] WeatherForecast model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var existingForecast = _weatherForecastRepo.GetById(id);
        if (existingForecast == null)
        {
            return NotFound();
        }

        // Update the fields
        existingForecast.Date = model.Date;
        existingForecast.TemperatureC = model.TemperatureC;
        existingForecast.Summary = model.Summary;

        _weatherForecastRepo.Update(existingForecast); // Save updated record

        return Ok(existingForecast); // Return updated weather forecast
    }
}

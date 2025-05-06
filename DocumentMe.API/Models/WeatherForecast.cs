using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DocumentMe.API.Models
{
    public class WeatherForecast
    {
        [Required]
        [JsonPropertyName("id")]
        [Display(Name = "Id", Description = "Uniq Id identifier")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("date")]
        [Display(Name = "Date", Description = "The date of the forecast in ISO format (yyyy-MM-dd).")]
        public DateOnly Date { get; set; }

        [Range(-100, 100)]
        [JsonPropertyName("temperatureC")]
        [Display(Name = "Temperature (C)", Description = "The temperature in Celsius, from -100 to 100.")]
        public int TemperatureC { get; set; }

        [Required]
        [JsonPropertyName("summary")]
        [Display(Name = "Summary", Description = "Short description of the weather (e.g. Sunny, Rainy).")]
        public string Summary { get; set; }
    }
}

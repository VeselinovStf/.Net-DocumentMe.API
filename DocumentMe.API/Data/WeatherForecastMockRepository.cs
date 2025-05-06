using DocumentMe.API.Data.Abstraction;
using DocumentMe.API.Models;

namespace DocumentMe.API.Data
{
    public class WeatherForecastMockRepository : IRepository<WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly List<WeatherForecast> WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Id = index,
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToList();

        public WeatherForecast Add(WeatherForecast entity)
        {
            entity.Id = WeatherForecasts.Count + 1;

            WeatherForecasts.Add(entity);

            return entity;
        }

        public List<WeatherForecast> GetAll() => WeatherForecasts;

        public WeatherForecast GetById(int id)
        {
            return WeatherForecasts.FirstOrDefault(e => e.Id == id);
        }

        public void Update(WeatherForecast updatedForecast)
        {
            var index = WeatherForecasts.FindIndex(f => f.Id == updatedForecast.Id);
            if (index == -1)
            {
                throw new KeyNotFoundException($"Weather forecast with Id {updatedForecast.Id} not found.");
            }

            WeatherForecasts[index].Date = updatedForecast.Date;
            WeatherForecasts[index].TemperatureC = updatedForecast.TemperatureC;
            WeatherForecasts[index].Summary = updatedForecast.Summary;
        }
    }
}

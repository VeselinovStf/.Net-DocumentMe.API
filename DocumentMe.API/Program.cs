
using DocumentMe.API.Data;
using DocumentMe.API.Data.Abstraction;
using DocumentMe.API.Models;
using DocumentMe.API.Swagger;

namespace DocumentMe.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Mock Data source
            builder.Services.AddSingleton<IRepository<WeatherForecast>, WeatherForecastMockRepository>();

            builder.Services.AddSwagger();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.Services.AddSwaggerFileToCurrentDirectory();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

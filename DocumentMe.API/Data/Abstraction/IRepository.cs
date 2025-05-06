using DocumentMe.API.Models;

namespace DocumentMe.API.Data.Abstraction
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T Add(T entity);
        T GetById(int id);
        void Update(WeatherForecast existingForecast);
    }
}

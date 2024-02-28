using MaxAuto.Models;

namespace MaxAuto.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car GetById(int id);
    }
}
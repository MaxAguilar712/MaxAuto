using MaxAuto.Models;

namespace MaxAuto.Repositories
{
    public interface ICarPartRepository
    {
        void Add(CarPart carpart);
        List<CarPart> GetAll();

        List<Part> GetParts();
        CarPart GetById(int id);
    }
}
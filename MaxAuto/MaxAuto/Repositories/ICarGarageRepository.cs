using MaxAuto.Models;

namespace MaxAuto.Repositories
{
    public interface ICarGarageRepository
    {
        void Add(CarGarage cargarage);
        List<CarGarage> GetAll();
        List<CarGarage> GetByUserId(int id);
    }
}
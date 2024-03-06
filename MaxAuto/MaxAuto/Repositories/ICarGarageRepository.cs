using MaxAuto.Models;

namespace MaxAuto.Repositories
{
    public interface ICarGarageRepository
    {
        void Add(CarGarage cargarage);
        void Delete(int garageCarId);
        List<CarGarage> GetAll();
        List<CarGarage> GetByUserId(int id);
    }
}
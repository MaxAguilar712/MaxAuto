using MaxAuto.Models;

namespace MaxAuto.Repositories
{
    public interface IPartRepository
    {
        List<Part> GetAll();
        Part GetById(int id);
    }
}
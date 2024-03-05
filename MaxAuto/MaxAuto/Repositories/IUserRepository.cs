using MaxAuto.Models;

namespace MaxAuto.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> GetAllProfiles();
        User GetByEmail(string email);
        User GetById(int Id);
        //List<UserProfile> GetByStatusId(int id);
        void UpdateMoney(User user);
    }
}
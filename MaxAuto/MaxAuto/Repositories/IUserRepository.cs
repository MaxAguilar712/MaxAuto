namespace MaxAuto.Repositories
{
    public interface IUserRepository
    {
        void Add(UserProfile userProfile);
        List<UserProfile> GetAllProfiles();
        UserProfile GetByEmail(string email);
        UserProfile GetById(int Id);
        List<UserProfile> GetByStatusId(int id);
        void UpdateStatusId(UserProfile user);
    }
}
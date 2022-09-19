using DemoT3.Domains;

namespace DemoT3.Repository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(String id);
        void InsertUser(User user);
        void DeleteUser(String userid);
        void UpdateUser(User user);
        void Save();
    }
}

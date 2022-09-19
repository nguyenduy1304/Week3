using DemoT3.Domains;
using DemoT3.Models;

namespace DemoT3.Interfaces
{
    public interface IUserSevice
    {
        IEnumerable<User> GetUsers();
        String CreateUser(CreateUserRequest createUserRequest);

    }
}

using DemoT3.Contract.Requests;
using DemoT3.Domains;

namespace DemoT3.Application.Interfaces
{
    public interface IUserSevice
    {
        IEnumerable<User> GetUsers(int? pageNumber);
        User GetUserByID(String id);
        String CreateUser(CreateUserRequest createUserRequest);
        void DeleteUser(String userid);
        void UpdateUser(EditUserRequest editUserRequest, String id);

        EditUserRequest GetEditUserRequest(String id);
    }
}

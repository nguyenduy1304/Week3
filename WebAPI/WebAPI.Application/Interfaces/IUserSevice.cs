using WebAPI.Contract.Requests;
using WebAPI.Contract.Response;
using WebAPI.Persistence.Domains;

namespace WebAPI.Application.Interfaces
{
    public interface IUserSevice
    {
        List<GetUserResponse> GetUsers();



        User GetUserByID(String id);
        EditUserRequest GetEditUserRequest(String id);
    }
}

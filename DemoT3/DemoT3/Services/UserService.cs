using DemoT3.Domains;
using DemoT3.Interfaces;
using DemoT3.Models;
using DemoT3.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;

namespace DemoT3.Services
{

    public class UserService : IUserSevice
    {
        private ApplicationDbContext _context;


        public UserService( ApplicationDbContext context)
        {
            _context = context;
        }

        public string CreateUser(CreateUserRequest createUserRequest)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = createUserRequest.Username,
                Email = createUserRequest.Email,
                Password = createUserRequest.Password,
            };
            _context.User.Add(user);

            var userDetail = new UserDetail 
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,  
                PhoneNumber = createUserRequest.PhoneNumber,
                Address = createUserRequest.Address,
                IdUser = user.Id,
            };
            _context.UserDetail.Add(userDetail);
            _context.SaveChanges();
            return user.Id;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.Include(c => c.UserDetail).AsNoTracking().ToList();
        }
    }

}

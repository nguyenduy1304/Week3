using DemoT3.Application.Interfaces;
using DemoT3.Contract.Requests;
using DemoT3.Domains;
using DemoT3.Persistence.Domains;
using Microsoft.EntityFrameworkCore;

namespace DemoT3.Application.Services
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

        public void DeleteUser(string userid)
        {
            User user = _context.User.Find(userid);
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserByID(string id)
        {
            return _context.User.Include(c => c.UserDetail).SingleOrDefault(c => c.Id.Equals(id));
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.Include(c => c.UserDetail).AsNoTracking().ToList();
        }

        public void UpdateUser(User user)
        {
            
        }
    }

}

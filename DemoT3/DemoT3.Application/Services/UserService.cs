using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public readonly IMapper _mapper;

        public UserService( ApplicationDbContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public string CreateUser(CreateUserRequest createUserRequest)
        {
            var _mappedUser = _mapper.Map<User>(createUserRequest);

            _mappedUser.Id = Guid.NewGuid().ToString();
            _mappedUser.UserDetail.IdUser = _mappedUser.Id;

            _context.User.Add(_mappedUser);
            _context.SaveChanges();
            return _mappedUser.Id;

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

        public void UpdateUser(EditUserRequest editUserRequest, String id)
        {
            var user = GetUserByID(id);
            user = _mapper.Map<EditUserRequest, User>(editUserRequest, user);
            _context.SaveChanges();
        }

        public EditUserRequest GetEditUserRequest(string id)
        {
            var user = _context.User.Include(c => c.UserDetail).SingleOrDefault(c => c.Id.Equals(id));
            return _mapper.Map<EditUserRequest>(user);
             
        }
    }

}

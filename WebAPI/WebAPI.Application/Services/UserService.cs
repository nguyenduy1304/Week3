using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Interfaces;
using WebAPI.Contract.Requests;
using WebAPI.Contract.Response;
using WebAPI.Persistence.DataContext;
using WebAPI.Persistence.Domains;

namespace WebAPI.Application.Services
{
    public class UserService : IUserSevice
    {
        private ApplicationDbContext _context;

        public readonly IMapper _mapper;

        public UserService(ApplicationDbContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetUserResponse> GetUsers()
        {
            var user = _context.User.Include(c => c.UserDetail).AsNoTracking().ToList();
            return _mapper.Map<List<GetUserResponse>>(user);
        }


        public User GetUserByID(string id)
        {
            return _context.User.Include(c => c.UserDetail).SingleOrDefault(c => c.Id.Equals(id));
        }
        public EditUserRequest GetEditUserRequest(string id)
        {
            var user = _context.User.Include(c => c.UserDetail).SingleOrDefault(c => c.Id.Equals(id));
            return _mapper.Map<EditUserRequest>(user);

        }
    }
}

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Interfaces;
using WebAPI.Contract.Requests;
using WebAPI.Persistence.DataContext;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IUserSevice _userSevice;

        public readonly IMapper _mapper;
        public HomeController(IUserSevice userSevice,
                                  IMapper mapper)
        {
            _userSevice = userSevice;
            _mapper = mapper;

        }

        [Route("api/home/getuser")]
        [HttpGet]
        public IActionResult Index()
        {
            var user = _userSevice.GetUsers();
            return Ok(user);
        }

    }
}

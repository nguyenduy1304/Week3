using AutoMapper;
using DemoT3.Application.Interfaces;
using DemoT3.Contract.Constant;
using DemoT3.Contract.Requests;
using DemoT3.Domains;
using DemoT3.Models;
using DemoT3.Persistence.Domains;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace DemoT3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserSevice _userSevice;

        private IValidator<CreateUserRequest> _validator;

        public readonly IMapper _mapper;

        private ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,
                                  IUserSevice userSevice,
                                  ApplicationDbContext context,
                                  IValidator<CreateUserRequest> validator,
                                  IMapper mapper)
        {
            _logger = logger;
            _userSevice = userSevice;
            _context = context;
            _validator = validator;
            _mapper = mapper;

        }

        public IActionResult Index(int? pageNumber)
        {
            return View(_userSevice.GetUsers(pageNumber ?? 1));
        }
        public IActionResult IndexVC(int? pageNumber)
        {
            var users = _userSevice.GetUsers(pageNumber ?? 1);
            return ViewComponent("User", users);
        }
        public ActionResult PartialViewUser(int? pageNumber)
        {
            return PartialView(_userSevice.GetUsers(pageNumber ?? 1));
        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(CreateUserRequest createUserRequest)
        {
            ValidationResult result = _validator.Validate(createUserRequest);
            try
            {
                if (!result.IsValid)
                {
                    result.AddToModelState(this.ModelState);
                    return View("AddUser", createUserRequest);

                }
                var userName = _context.User.SingleOrDefault(u => u.Username == createUserRequest.Username);
                var email = _context.User.SingleOrDefault(e => e.Email == createUserRequest.Email);
                if (userName != null && email != null)
                {
                    ViewBag.Error = "Username and Email exist";
                    return View();
                }
                if (userName != null)
                {
                    ViewBag.Error = "Username exist";
                    return View();
                }
                if (email != null)
                {
                    ViewBag.Error = "Email exist";
                    return View();
                }

                _userSevice.CreateUser(createUserRequest);

                _logger.LogInformation("Create new user successfully.");

                return RedirectToAction("Index");

            }
            catch (DataException)
            {
                _logger.LogError("Create new user Failed");
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditUser(String id)
        {
            var userid = _userSevice.GetEditUserRequest(id);
            ViewBag.UserId = id;
           
            return View(userid);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUsers(EditUserRequest editUserRequest, String id)
        {
            ViewBag.UserId = id;
            _userSevice.UpdateUser(editUserRequest, id);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(String id)
        {
            try
            {
                _userSevice.DeleteUser(id);
                _logger.LogInformation("Delete user successfully");
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ViewBag.Error = "Delete user Failed";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using DemoT3.Interfaces;
using DemoT3.Models;
using DemoT3.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace DemoT3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserSevice _userSevice;

        public HomeController(ILogger<HomeController> logger,
                                  IUserSevice userSevice)
        {
            _logger = logger;
            _userSevice = userSevice;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult PartialViewUser()
        {
            var users = _userSevice.GetUsers();
            return PartialView(users);
        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(CreateUserRequest createUserRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _userSevice.CreateUser(createUserRequest);

                    _logger.LogInformation("Create new user successfully.");

                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Error = "Create new user Failed";
                    return View(createUserRequest);
                }

            }
            catch (DataException)
            {
                _logger.LogError("Create new user Failed");
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
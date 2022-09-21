using AutoMapper;
using DemoT3.Application.Interfaces;
using DemoT3.Contract.Requests;
using DemoT3.Controllers;
using DemoT3.Persistence.Domains;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DemoT3.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IUserSevice _userSevice;

        public UserViewComponent(IUserSevice userSevice)
        {
            _userSevice = userSevice;
        }
        public IViewComponentResult Invoke()
        {
            return View(_userSevice.GetUsers());
        }
    }
}

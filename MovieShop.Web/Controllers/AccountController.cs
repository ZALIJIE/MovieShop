using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Core.Models.Response;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        //When user click the submit btn
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var createdUser = await _userService.CreateUser(model);
                return Redirect("Login");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {

            return View();
        }
    }
}

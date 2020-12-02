using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Core.Models.Response;
using MovieShop.Core.Models.Request;


namespace MovieShop.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        //When user click the submit btn
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterResponseModel model)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
            return View();
        }
    }
}

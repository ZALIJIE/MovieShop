using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequest)
        {
            if (ModelState.IsValid)
            {
                //Call user service
                return Ok();
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAccountByIdAsync(int id)
        {
            var user = await _userService.GetUserDetails(id);
            if (user!=null)
            {
                return Ok(user);
            }
            return BadRequest(new { message = "User not found" });

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var user =await  _userService.ValidateUser(model.Email, model.Password);
            if (ModelState.IsValid)
            {
                return Ok(user);
            }
            return BadRequest(new { message = "Login failed" });
        }
    }
}

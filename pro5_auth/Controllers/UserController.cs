using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using pro5_auth.DTO;
using pro5_auth.Services.IServices;

namespace pro5_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]

        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var result = await _userService.Register(userRegisterDto);
            return Ok(result);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var result = await _userService.Login(loginRequestDto);
                return Ok(new { messae = "login done", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "login failed",
                    error = ex.Message

                });
            }
        }



    }
}
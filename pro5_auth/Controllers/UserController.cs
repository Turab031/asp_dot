using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


    }
}
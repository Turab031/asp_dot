using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pro2.Dto;
using pro2.GenericsResponse;
using pro2.IService;

namespace pro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }
        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            try
            {
                var result = await _authService.LoginUser(userDto);
                if (result.Item1 == 0)
                {
                    return NotFound(ResponseResult<string>.Failure(null, result.Item2));
                }
                if (result.Item1 == 1)
                {
                    return BadRequest(ResponseResult<string>.Failure(null, result.Item2));
                }



                return Ok(ResponseResult<string>.Success(null, result.Item2));


            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong: " + ex.Message);

            }
        }


    }
}
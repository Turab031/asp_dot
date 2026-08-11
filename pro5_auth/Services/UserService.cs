using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using pro5_auth.DTO;
using pro5_auth.Services.IServices;

namespace pro5_auth.Services
{

    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }


        public async Task<UserResponseDto> Register(UserRegisterDto userRegisterDto)
        {
            var user = new UserModel
            {

                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                Username = userRegisterDto.Username,
                Password = userRegisterDto.Password,

            };

            _context.UserModels.Add(user);

            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username
            };
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.UserModels.FirstOrDefaultAsync(u => u.Username == loginRequestDto.UserName);

            if (user == null)
            {
                throw new Exception("user not found");

            }

            var token = GenerateToken(user);
            return new LoginResponseDto
            {
                Token = token,
                User = new UserResponseDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.Username


                }
            };



        }

        private string GenerateToken(UserModel user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // payload
            var claims = new[]
            {
                new Claim("Id",user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim("UserName",user.Username),
                new Claim(ClaimTypes.Email,user.Email),



            };

            // signature

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);




        }




    }
}
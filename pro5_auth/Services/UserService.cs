using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro5_auth.DTO;
using pro5_auth.Services.IServices;

namespace pro5_auth.Services
{

    public class UserService:IUserService
    {
        private readonly ApplicationDBContext _context;

        public UserService(ApplicationDBContext context)
        {
            _context = context;

        }


        public async Task<UserResponseDto> Register(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
               
                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email,
                Username = userRegisterDto.Username,
                Password = userRegisterDto.Password,

            };

            _context.users.Add(user);

            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pro2.Data;
using pro2.Dto;
using pro2.IService;

namespace pro2.Services
{


    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;


        }
        public async Task<Tuple<int, string>> LoginUser(UserDto dto)
        {
            try
            {

                var existingUser = await _context.AccountUsers.FirstOrDefaultAsync(x => x.Email == dto.Email);
                if (existingUser == null)
                {
                    return new Tuple<int, string>(0,"this user does not exist, please login");
                }
                if(existingUser.Password != dto.Password)
                {
                    return new Tuple<int, string>(1,"Password incorrect");
                }
                return new Tuple<int, string>(2,"Login succesfull");
            }
            catch(Exception)
            {
                return new Tuple<int, string>(3,"something went wrong");


            }

        }

    }
}
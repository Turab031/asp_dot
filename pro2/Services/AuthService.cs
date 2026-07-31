using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
                if (dto == null)
                {
                    return new Tuple<int, string>(1, "please fill all clolumns");
                }


                var existingUser = await _context.AccountUsers.FirstOrDefaultAsync(x => x.Email == dto.Email);
                if (existingUser == null)
                {
                    return new Tuple<int, string>(0, "this user does not exist, please login");
                }
                // if(existingUser.Password != dto.Password)
                // {
                //     return new Tuple<int, string>(1,"Password incorrect");
                // }

                var passwordHasher = new PasswordHasher<string>();
                var verifyPassword = passwordHasher.VerifyHashedPassword(dto.Email, existingUser.Password, dto.Password);
                if (verifyPassword == PasswordVerificationResult.Success)
                {
                    return new Tuple<int, string>(2, "Login succesfull");


                }
                else if (verifyPassword == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    existingUser.Password = PasswordHashing(dto);
                    _context.AccountUsers.Update(existingUser);
                    _context.SaveChanges();
                    return new Tuple<int, string>(2, "Login succesfull");

                }
                else if (verifyPassword == PasswordVerificationResult.Failed)
                {
                    return new Tuple<int, string>(1, "password incorrect");

                }
                return new Tuple<int, string>(1, "");



            }
            catch (Exception)
            {
                return new Tuple<int, string>(3, "something went wrong");


            }

        }


        public async Task<Tuple<int, string>> RegisterUser(UserDto dto)
        {
            try
            {
                var existingUser = await _context.AccountUsers.AnyAsync(x => x.Email == dto.Email);
                if (existingUser)
                {
                    return new Tuple<int, string>(0, "this user already exist,please register with new id ");

                }
                _context.AccountUsers.Add(new Entities.User
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = PasswordHashing(dto)


                });
                await _context.SaveChangesAsync();
                return new Tuple<int, string>(1, "user registered successfully");

            }
            catch (Exception)
            {
                throw;

            }
        }

        private string PasswordHashing(UserDto dto)
        {
            var passwordHasher = new PasswordHasher<string>();

            var hash = passwordHasher.HashPassword(dto.Email, dto.Password);
            return hash;
        }




    }
}
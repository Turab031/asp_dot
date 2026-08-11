using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro5_auth.DTO;

namespace pro5_auth.Services.IServices
{
    public interface IUserService
    {
        Task<UserResponseDto> Register(UserRegisterDto userRegisterDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

    }
}
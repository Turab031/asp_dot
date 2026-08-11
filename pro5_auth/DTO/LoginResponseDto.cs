using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro5_auth.DTO
{
    public class LoginResponseDto
    {
        public string Token{get;set;}=string.Empty;
        public UserResponseDto User{get;set;}
    }
}
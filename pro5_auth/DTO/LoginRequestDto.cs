using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro5_auth.DTO
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;


    }
}
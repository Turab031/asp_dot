using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro3.DTO
{
    public class UserDto
    {
        
        public string Username {get;set;} = string.Empty;
        public string PasswordHash{get;set;} = string.Empty;
    }
}
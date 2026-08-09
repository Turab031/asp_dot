using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro5_auth.DTO
{
    public class UserResponseDto
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
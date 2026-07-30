using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pro2.Dto
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; } =Guid.NewGuid();

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro5_auth.DTO
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name{get;set;}=string.Empty;

        public string Description{get;set;}=string.Empty;

        public int Price { get; set; }

        
    }
}
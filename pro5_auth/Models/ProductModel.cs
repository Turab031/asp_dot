using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro5_auth.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name{get;set;}=string.Empty;

        public string Description{get;set;}=string.Empty;

        public int Price { get; set; }



    }
}
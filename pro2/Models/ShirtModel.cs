using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro2.Models
{
    public class ShirtModel
    {
        public int ShirtId { get; set; }
        public string Brand{get;set;}=string.Empty;
        public string Color{get;set;} = string.Empty;
        public int Size {get;set;}

        public string Gender {get;set;} = string.Empty;
        public double Price{get;set;}

    }
}
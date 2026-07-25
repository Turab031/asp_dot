using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project1.Models
{
    public class StudentModel
    {
        public int studId{get;set;}
        public string studName { get; set; }=string.Empty;
        public string email { get; set; }=string.Empty;

        public bool isActive{get;set;}


    }
}
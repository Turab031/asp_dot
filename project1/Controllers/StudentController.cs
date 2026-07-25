using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project1.Models;

namespace project1.Controllers
{
    [ApiController]
    [Route("getStudentList")]

    public class StudentController : ControllerBase
    {
        [HttpGet]
        public List<StudentModel> getAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            StudentModel _stu1 = new StudentModel()

            {
                email = "demo@gmail.com",

                isActive = true,
                studId = 121,
                studName = "demo"

            };
            students.Add(_stu1);
            StudentModel _stu2 = new StudentModel()
            {
                email = "demo1@gmail.com",
                isActive = true,
                studName = "demo1",
                studId = 123
            };
            students.Add(_stu2);
            StudentModel _stu3 = new StudentModel()
            {
                email = "demo3@gmail.com",
                isActive = false,
                studName = "demo3",
                studId=125
                

            };
            students.Add(_stu3);
            return students;
        }



    }
}
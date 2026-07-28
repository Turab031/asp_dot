using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pro2.Models;

namespace pro2.Controllers
{

    [ApiController]

    [Route("/api/[controller]")]
    public class ShirtController : ControllerBase
    {
        [HttpGet]
        
        public string GetShirts()
        {
            return "reading all shirts";
        }
        [HttpGet("{id}")]
      
        public string GetShirtsById(int id)
        {
            return $"reding shirt :{id}";
        }

        [HttpPost]
       
        public string CreateShirt( [FromBody] ShirtModel shirt)
        {
            return "creating shirt";
        }

        [HttpPut("{id}")]
     
        public string UpdateShirt(int id)
        {
            return $"updating shirt : {id}";
        }
        [HttpDelete("{id}")]



        public string DeleteShirt(int id)
        {
            return $"deleting shirt:{id}";
        }

    }
}
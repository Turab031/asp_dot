using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pro6_lc.Models;

namespace pro6_lc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        EcomDbContext _context;
        public CategoryController()
        {
            
        }
    }
}
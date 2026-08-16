using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore ;

namespace pro6_lc.Models
{
    public class EcomDbContext : DbContext

    {
        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options)
        {

        }
    }
}
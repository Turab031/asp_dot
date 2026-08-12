using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pro5_auth.Models;

namespace pro5_auth
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<ProductModel> Products { get; set; }

    }
}
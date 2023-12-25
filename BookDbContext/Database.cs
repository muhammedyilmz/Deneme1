using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme1.Models;
using Microsoft.EntityFrameworkCore;

namespace Deneme1.BookDbContext
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Library; User Id=SA; Password=reallyStrongPwd123; Trust Server Certificate=true;");
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Hire>? Hires { get; set; }
        public DbSet<User>? Users { get; set; }

    }

}

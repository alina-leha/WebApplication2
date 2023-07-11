using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<user> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
            => option.UseSqlite(@"Data Source = Models\users.db");

    }
}

using Microsoft.EntityFrameworkCore;
using prac12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac12.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ANDRE\\SQLEXPRESS;Database=Prac12DB;Trusted_Connection=True;TrustServerCertificate=True;");
}
    }
}

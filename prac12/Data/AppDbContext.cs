using Microsoft.EntityFrameworkCore;
using prac12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prac12.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ANDRE\\SQLEXPRESS;Database=Prac12DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(s => s.UserProfile)
                .WithOne(ps => ps.User)
                .HasForeignKey<UserProfile>(ps => ps.UserId)
                .IsRequired(false);

            modelBuilder.Entity<Role>()
                .HasMany(g => g.Users)
                .WithOne(s => s.Role)
                .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(cs => new { cs.UserId, cs.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(cs => cs.User)
                .WithMany(s => s.UserInterestGroups)
                .HasForeignKey(cs => cs.UserId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(cs => cs.InterestGroup)
                .WithMany(c => c.UserInterestGroups)
                .HasForeignKey(cs => cs.InterestGroupId);
        }
    }
}

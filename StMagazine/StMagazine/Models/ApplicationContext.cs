using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StMagazine.Models
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
       public DbSet<Student> Students { get; set; }
       public DbSet<Group> Groups { get; set; }
       public DbSet<Cours> Courses { get; set; }
       public DbSet<Item> Items { get; set; }
       public DbSet<Teacher> Teachers { get; set; }
       //public DbSet<Role> Roles { get; set; }
       //public DbSet<Admin> Admins { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Novin.Foodland.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Foodland.Infrastructure.Data
{
    public class NovinFoodlandDB : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public NovinFoodlandDB(DbContextOptions<NovinFoodlandDB> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(p => p.Username);
        }
    }
}

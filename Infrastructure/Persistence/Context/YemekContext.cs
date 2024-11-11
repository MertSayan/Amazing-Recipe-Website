using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class YemekContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=YemekProjesi;User=TestUser;Password=321321;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.RateList)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction); // veya DeleteBehavior.Restrict

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Recipe)
                .WithMany(re => re.RateList)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.NoAction); // veya DeleteBehavior.Restrict
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeMaterial> RecipeMaterials { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<About> Abouts { get; set; }

    }
}

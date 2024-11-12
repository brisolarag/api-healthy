using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet;
using api.healthy.src.components.users;
using Microsoft.EntityFrameworkCore;

namespace api.healthy.src.context
{
    public class ApiContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DietModel> Diets { get; set; }


        public ApiContext(DbContextOptions<ApiContext> options) : base(options) {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            // {
            //     optionsBuilder.UseSqlite("Data Source=database/healthy.db");
            // }
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SetupEntities();
        }
    }
}
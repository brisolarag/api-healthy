using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet;
using api.healthy.src.components.users;
using Microsoft.EntityFrameworkCore;

namespace api.healthy.src.context
{
    public static class DatabaseSettings
    {
        public static void SetupEntities(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserModel>().HasKey(u => u.Cpf);
            modelBuilder.Entity<UserModel>().Property(u => u.FullName).HasMaxLength(100);
            modelBuilder.Entity<UserModel>().Property(u => u.Email).HasMaxLength(100);


            modelBuilder.Entity<DietModel>().HasKey(u => u.Id);
        }
    }
}
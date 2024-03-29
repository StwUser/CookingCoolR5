﻿using CookingCoolR5.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CookingCoolR5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<EmailVerification> EmailVerifications { get; set; }

        public DbSet<GameModel> GameModels { get; set; }
    }
}

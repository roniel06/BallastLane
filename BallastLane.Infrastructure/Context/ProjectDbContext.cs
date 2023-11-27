﻿using BallastLane.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BallastLane.Infrastructure.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ballastlane.db");
        }

        public DbSet<User> Users { get; set; }
    }
}
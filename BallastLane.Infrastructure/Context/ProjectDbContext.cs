﻿using BallastLane.Infrastructure.Context.Configurations;
using BallastLane.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BallastLane.Infrastructure.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEFConfigurations());
            modelBuilder.ApplyConfiguration(new NotesEFConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}

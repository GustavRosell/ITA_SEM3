using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class StudioContext : DbContext
    {
        public DbSet<Studio> Studios { get; set; }
        public string DbPath { get; }

        public StudioContext()
        {
            DbPath = "bin/Studios.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studio>().ToTable("Studios");
        }
    }
}
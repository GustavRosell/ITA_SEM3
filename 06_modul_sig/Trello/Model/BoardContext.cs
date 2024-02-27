using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public string DbPath { get; }

        public BoardContext()
        {
            DbPath = "bin/Boards.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Boards");
        }
    }
}


using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// TodoContext.cs

namespace Model
{
    public class BoardContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public string DbPath { get; }

        public BoardContext()
        {
            DbPath = "bin/Board.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
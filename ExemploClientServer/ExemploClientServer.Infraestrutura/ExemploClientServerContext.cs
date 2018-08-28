﻿using ExemploClientServer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExemploClientServer.Infraestrutura
{
    public class ExemploClientServerContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Process> Process { get; set; }

        public ExemploClientServerContext()
        {
        }

        public ExemploClientServerContext(DbContextOptions<ExemploClientServerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ExemploClientServer;Trusted_Connection=True;");
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}

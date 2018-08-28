using ExemploClientServer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploClientServer.Infra
{
    public partial class ExemploClientServerContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ExemploClientServer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}

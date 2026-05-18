using Celulares.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Celulares.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Celular> Celulares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Celular>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Marca).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Modelo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IMEI).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Precio).HasPrecision(18,2);
                entity.Property(e => e.Stock).IsRequired();
            });
        }
    }
}

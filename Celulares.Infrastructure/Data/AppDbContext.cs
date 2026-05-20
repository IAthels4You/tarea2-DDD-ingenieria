using Celulares.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Celulares.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //esta clase representa el contexto de la base de datos, es decir,
        //la conexión a la base de datos y la configuración de las entidades que se van a mapear a las tablas de la base de datos.
        //se utiliza Entity Framework Core para manejar el acceso a datos, y se define un DbSet para la entidad Celular, que representa la tabla de celulares en la base de datos.
        //Esta clase es la que permite el uso de unit of work, ya que el contexto de la base de datos guarda los cambios en su propio estado en memoria,
        //y luego se pueden guardar todos los cambios de manera atómica al llamar a "SaveChangesAsync" o "CommitAsync" en el Unit of Work.
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

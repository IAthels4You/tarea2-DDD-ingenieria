using Celulares.Domain.Entities;
using Celulares.Domain.Interfaces;
using Celulares.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Celulares.Infrastructure.Repositories
{
    public class CelularRepository : ICelularRepository
    {
        //esta es la implemetación concreta del repositorio, que se encarga de interactuar con la base de datos utilizando Entity Framework Core.
        //no hace un guardado directo a la base de datos, sino que simplemente prepara las operaciones (como agregar, actualizar o eliminar) en el contexto de la base de datos,
        //y luego el Unit of Work se encarga de guardar todos los cambios de manera atómica al llamar a "CommitAsync".
        private readonly AppDbContext _context;

        public CelularRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Celular?> GetByIdAsync(Guid id)
        {
            return await _context.Celulares.FindAsync(id);
        }

        public async Task<IEnumerable<Celular>> GetAllAsync()
        {
            return await _context.Celulares.ToListAsync();
        }

        public async Task AddAsync(Celular celular)
        {
            await _context.Celulares.AddAsync(celular);
        }

        public void Update(Celular celular)
        {
            _context.Celulares.Update(celular);
        }

        public void Delete(Celular celular)
        {
            _context.Celulares.Remove(celular);
        }
    }
}

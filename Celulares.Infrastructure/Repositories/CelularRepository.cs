using Celulares.Domain.Entities;
using Celulares.Domain.Interfaces;
using Celulares.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Celulares.Infrastructure.Repositories
{
    public class CelularRepository : ICelularRepository
    {
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

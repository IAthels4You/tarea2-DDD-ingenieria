using Celulares.Domain.Interfaces;
using Celulares.Infrastructure.Data;

namespace Celulares.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //implementación concreta del Unit of Work, que en este caso solamente tiene un método
        //"CommitAsync" que llama a "SaveChangesAsync" del contexto de la base de datos para guardar todos los cambios de manera atómica.
        //Es un patrón muy interesante porque permite coordinar todas las operaciones que involucran cambios en la base de datos de manera sencilla y eficiente,
        //sobretodo cuando en una operación o caso de uso interactúan varias entidades e involucra múltiples operaciones y cambios en BD que deben ser atómicas.
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

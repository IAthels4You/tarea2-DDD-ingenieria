using Celulares.Domain.Entities;

namespace Celulares.Domain.Interfaces
{
    public interface ICelularRepository
    {
        Task<Celular?> GetByIdAsync(Guid id);
        Task<IEnumerable<Celular>> GetAllAsync();
        Task AddAsync(Celular celular);
        void Update(Celular celular);
        void Delete(Celular celular);
    }
}

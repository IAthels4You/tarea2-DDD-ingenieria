using Celulares.Application.DTOs;

namespace Celulares.Application.Interfaces
{
    public interface ICelularApplicationService
    {
        Task<CelularDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CelularDto>> GetAllAsync();
        Task<CelularDto> CreateAsync(CrearCelularDto dto);
        Task UpdateAsync(Guid id, ActualizarCelularDto dto);
        Task DeleteAsync(Guid id);
    }
}

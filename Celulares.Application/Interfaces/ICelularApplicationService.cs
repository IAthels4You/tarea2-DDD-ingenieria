using Celulares.Application.DTOs;

namespace Celulares.Application.Interfaces
{
    public interface ICelularApplicationService
    {
        //interfaz del servicio de aplicación, define las operaciones que se pueden realizar con los celulares
        //Se utiliza para tener una capa de abstracción entre el controlador y la lógica de negocio, el controlador depende de esta interfaz
        //de esta manera se favorece el bajo acoplamiento y es muy bueno para pruebas y uso de mocks
        Task<CelularDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CelularDto>> GetAllAsync();
        Task<CelularDto> CreateAsync(CrearCelularDto dto);
        Task UpdateAsync(Guid id, ActualizarCelularDto dto);
        Task DeleteAsync(Guid id);
    }
}

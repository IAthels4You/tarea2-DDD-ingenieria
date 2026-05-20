using Celulares.Application.DTOs;
using Celulares.Application.Interfaces;
using Celulares.Domain.Entities;
using Celulares.Domain.Interfaces;

namespace Celulares.Application.Services
{
    public class CelularApplicationService : ICelularApplicationService
    {
        // El servicio de aplicación es la capa que orquesta las operaciones relacionadas con los celulares, es decir,
        // contiene la lógica para manejar las operaciones CRUD (Crear, Leer, Actualizar, Eliminar).
        //no contiene lógica de negocio, solo coordina las operaciones entre el controlador y el repositorio
        private readonly ICelularRepository _repository;

        //Algo importante es que el servicio de aplicación también maneja el Unit of Work, mencionado en la lectura,
        //que es un patrón que se encarga de coordinar las operaciones que involucran cambios en el estado de la base de datos,
        //asegurando que todas las operaciones se realicen correctamente o se deshagan en caso de error.
        //básicamente asegura que las diferentes operaciones que involucran cambios en base de datos se hagan de manera atómica
        private readonly IUnitOfWork _unitOfWork;

        public CelularApplicationService(ICelularRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CelularDto?> GetByIdAsync(Guid id)
        {
            var celular = await _repository.GetByIdAsync(id);
            if (celular == null) return null;

            return MapToDto(celular);
        }

        public async Task<IEnumerable<CelularDto>> GetAllAsync()
        {
            var celulares = await _repository.GetAllAsync();
            return celulares.Select(MapToDto);
        }

        public async Task<CelularDto> CreateAsync(CrearCelularDto dto)
        {
            var celular = new Celular(dto.Marca, dto.Modelo, dto.IMEI, dto.Precio, dto.Stock);
            
            await _repository.AddAsync(celular);
            await _unitOfWork.CommitAsync();

            return MapToDto(celular);
        }

        public async Task UpdateAsync(Guid id, ActualizarCelularDto dto)
        {
            var celular = await _repository.GetByIdAsync(id);
            if (celular == null) throw new KeyNotFoundException("Celular no encontrado.");

            celular.Actualizar(dto.Marca, dto.Modelo, dto.IMEI, dto.Precio, dto.Stock);
            
            _repository.Update(celular);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var celular = await _repository.GetByIdAsync(id);
            if (celular == null) throw new KeyNotFoundException("Celular no encontrado.");

            _repository.Delete(celular);
            await _unitOfWork.CommitAsync();
        }

        private static CelularDto MapToDto(Celular celular)
        {
            return new CelularDto
            {
                Id = celular.Id,
                Marca = celular.Marca,
                Modelo = celular.Modelo,
                IMEI = celular.IMEI,
                Precio = celular.Precio,
                Stock = celular.Stock,
                FechaCreacion = celular.FechaCreacion
            };
        }
    }
}

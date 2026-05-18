using Celulares.Application.DTOs;
using Celulares.Application.Interfaces;
using Celulares.Domain.Entities;
using Celulares.Domain.Interfaces;

namespace Celulares.Application.Services
{
    public class CelularApplicationService : ICelularApplicationService
    {
        private readonly ICelularRepository _repository;
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

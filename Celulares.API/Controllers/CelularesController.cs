using Celulares.Application.DTOs;
using Celulares.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Celulares.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelularesController : ControllerBase
    {
        private readonly ICelularApplicationService _service;

        public CelularesController(ICelularApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CelularDto>>> GetAll()
        {
            var celulares = await _service.GetAllAsync();
            return Ok(celulares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CelularDto>> GetById(Guid id)
        {
            var celular = await _service.GetByIdAsync(id);
            if (celular == null) return NotFound();

            return Ok(celular);
        }

        [HttpPost]
        public async Task<ActionResult<CelularDto>> Create([FromBody] CrearCelularDto dto)
        {
            var celular = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = celular.Id }, celular);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ActualizarCelularDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

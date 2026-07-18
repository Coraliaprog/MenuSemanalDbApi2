using Aplicacion.Service;
using Dominio.Entidades;
using MenuSemana1DbApi.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemana1DbApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComidasController : ControllerBase
    {
        private readonly ComidaService _comidaService;

        public ComidasController(ComidaService comidaService)
        {
            _comidaService = comidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comida>>> Get()
        {
            var comidas = await _comidaService.ObtenerTodasAsync();

            return Ok(comidas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comida>> Get(int id)
        {
            var comida = await _comidaService.ObtenerPorIdAsync(id);

            if (comida == null)
            {
                return NotFound();
            }

            return Ok(comida);
        }

        [HttpPost]
        public async Task<ActionResult<Comida>> Post(CreateComidaDto dto)
        {
            var comida = new Comida
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                MenuSemanalId = dto.MenuSemanalId
            };

            await _comidaService.CrearAsync(comida);

            return CreatedAtAction(nameof(Get), new { id = comida.Id }, comida);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Comida>> Put(int id, UpdateComidaDto dto)
        {
            var comida = new Comida
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                MenuSemanalId = dto.MenuSemanalId
            };

            var resultado = await _comidaService.ActualizarAsync(id, comida);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _comidaService.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
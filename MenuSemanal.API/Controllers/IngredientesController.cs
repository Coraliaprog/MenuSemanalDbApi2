using Dominio.Entidades;
using Infraestructura.AccesoDatos.Interfaces;
using MenuSemana1DbApi.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemana1DbApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredientesController(
            IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> Get()
        {
            var ingredientes =
                await _ingredienteRepository.ObtenerTodosAsync();

            return Ok(ingredientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> Get(int id)
        {
            var ingrediente =
                await _ingredienteRepository.ObtenerPorIdAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return Ok(ingrediente);
        }

        [HttpPost]
        public async Task<ActionResult<Ingrediente>> Post(
            CreateIngredienteDto dto)
        {
            var ingrediente = new Ingrediente
            {
                Nombre = dto.Nombre,
                Cantidad = dto.Cantidad,
                UnidadMedida = dto.UnidadMedida,
                ComidaId = dto.ComidaId
            };

            await _ingredienteRepository.CrearAsync(ingrediente);

            return CreatedAtAction(
                nameof(Get),
                new { id = ingrediente.Id },
                ingrediente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ingrediente>> Put(
            int id,
            UpdateIngredienteDto dto)
        {
            var ingrediente = new Ingrediente
            {
                Nombre = dto.Nombre,
                Cantidad = dto.Cantidad,
                UnidadMedida = dto.UnidadMedida,
                ComidaId = dto.ComidaId
            };

            var resultado =
                await _ingredienteRepository.ActualizarAsync(
                    id,
                    ingrediente);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado =
                await _ingredienteRepository.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
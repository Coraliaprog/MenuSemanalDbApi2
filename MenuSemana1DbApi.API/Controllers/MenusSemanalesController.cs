using Aplicacion.Service;
using Dominio.Entidades;
using MenuSemana1DbApi.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemana1DbApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenusSemanalesController : ControllerBase
    {
        private readonly MenuSemanalService _menuSemanalService;

        public MenusSemanalesController(
            MenuSemanalService menuSemanalService)
        {
            _menuSemanalService = menuSemanalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuSemanal>>> Get()
        {
            var menusSemanales =
                await _menuSemanalService.ObtenerTodosAsync();

            return Ok(menusSemanales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuSemanal>> Get(int id)
        {
            var menuSemanal =
                await _menuSemanalService.ObtenerPorIdAsync(id);

            if (menuSemanal == null)
            {
                return NotFound();
            }

            return Ok(menuSemanal);
        }

        [HttpPost]
        public async Task<ActionResult<MenuSemanal>> Post(
            CreateMenuSemanalDto dto)
        {
            var menuSemanal = new MenuSemanal
            {
                Nombre = dto.Nombre,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            await _menuSemanalService.CrearAsync(menuSemanal);

            return CreatedAtAction(
                nameof(Get),
                new { id = menuSemanal.Id },
                menuSemanal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MenuSemanal>> Put(
            int id,
            UpdateMenuSemanalDto dto)
        {
            var menuSemanal = new MenuSemanal
            {
                Nombre = dto.Nombre,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            var resultado =
                await _menuSemanalService.ActualizarAsync(
                    id,
                    menuSemanal);

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
                await _menuSemanalService.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
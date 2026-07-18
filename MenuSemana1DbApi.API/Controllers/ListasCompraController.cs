using Aplicacion.Service;
using Dominio.Entidades;
using MenuSemana1DbApi.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MenuSemana1DbApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListasCompraController : ControllerBase
    {
        private readonly ListaCompraService _listaCompraService;

        public ListasCompraController(
            ListaCompraService listaCompraService)
        {
            _listaCompraService = listaCompraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaCompra>>> Get()
        {
            var listasCompra =
                await _listaCompraService.ObtenerTodasAsync();

            return Ok(listasCompra);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListaCompra>> Get(int id)
        {
            var listaCompra =
                await _listaCompraService.ObtenerPorIdAsync(id);

            if (listaCompra == null)
            {
                return NotFound();
            }

            return Ok(listaCompra);
        }

        [HttpPost]
        public async Task<ActionResult<ListaCompra>> Post(
            CreateListaCompraDto dto)
        {
            var listaCompra = new ListaCompra
            {
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                UnidadMedida = dto.UnidadMedida,
                Comprado = dto.Comprado
            };

            await _listaCompraService.CrearAsync(listaCompra);

            return CreatedAtAction(
                nameof(Get),
                new { id = listaCompra.Id },
                listaCompra);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ListaCompra>> Put(
            int id,
            UpdateListaCompraDto dto)
        {
            var listaCompra = new ListaCompra
            {
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                UnidadMedida = dto.UnidadMedida,
                Comprado = dto.Comprado
            };

            var resultado =
                await _listaCompraService.ActualizarAsync(
                    id,
                    listaCompra);

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
                await _listaCompraService.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
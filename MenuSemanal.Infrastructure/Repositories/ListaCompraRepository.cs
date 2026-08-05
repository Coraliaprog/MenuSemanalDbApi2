using Dominio.Entidades;
using Infraestructura.AccesoDatos.Contexto;
using Infraestructura.AccesoDatos.Interfaces;
using Infraestructura.Core;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositories
{
    public class ListaCompraRepository : BaseRepository<ListaCompra>, IListaCompraRepository
    {
        public ListaCompraRepository(MenuSemanalDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<ListaCompra>> ObtenerTodasAsync()
        {
            return await _context.ListasCompra.ToListAsync();
        }

        public async Task<ListaCompra?> ObtenerPorIdAsync(int id)
        {
            return await _context.ListasCompra.FindAsync(id);
        }

        public async Task<ListaCompra> CrearAsync(ListaCompra listaCompra)
        {
            _context.ListasCompra.Add(listaCompra);
            await _context.SaveChangesAsync();

            return listaCompra;
        }

        public async Task<ListaCompra?> ActualizarAsync(int id, ListaCompra listaCompra)
        {
            var listaExistente = await _context.ListasCompra.FindAsync(id);

            if (listaExistente == null)
            {
                return null;
            }

            listaExistente.Producto = listaCompra.Producto;
            listaExistente.Cantidad = listaCompra.Cantidad;
            listaExistente.UnidadMedida = listaCompra.UnidadMedida;
            listaExistente.Comprado = listaCompra.Comprado;

            await _context.SaveChangesAsync();

            return listaExistente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var listaCompra = await _context.ListasCompra.FindAsync(id);

            if (listaCompra == null)
            {
                return false;
            }

            _context.ListasCompra.Remove(listaCompra);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
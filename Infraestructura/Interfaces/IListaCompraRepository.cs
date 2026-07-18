using Dominio.Entidades;

namespace Infraestructura.AccesoDatos.Interfaces
{
    public interface IListaCompraRepository
    {
        Task<IEnumerable<ListaCompra>> ObtenerTodasAsync();

        Task<ListaCompra?> ObtenerPorIdAsync(int id);

        Task<ListaCompra> CrearAsync(ListaCompra listaCompra);

        Task<ListaCompra?> ActualizarAsync(int id, ListaCompra listaCompra);

        Task<bool> EliminarAsync(int id);
    }
}
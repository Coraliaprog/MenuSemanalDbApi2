using Dominio.Entidades;
using Infraestructura.AccesoDatos.Interfaces;


namespace Aplicacion.Service
{
    public class ListaCompraService
    {
        private readonly IListaCompraRepository _listaCompraRepository;

        public ListaCompraService(
            IListaCompraRepository listaCompraRepository)
        {
            _listaCompraRepository = listaCompraRepository;
        }

        public async Task<IEnumerable<ListaCompra>> ObtenerTodasAsync()
        {
            return await _listaCompraRepository.ObtenerTodasAsync();
        }

        public async Task<ListaCompra?> ObtenerPorIdAsync(int id)
        {
            return await _listaCompraRepository.ObtenerPorIdAsync(id);
        }

        public async Task<ListaCompra> CrearAsync(ListaCompra listaCompra)
        {
            return await _listaCompraRepository.CrearAsync(listaCompra);
        }

        public async Task<ListaCompra?> ActualizarAsync(
            int id,
            ListaCompra listaCompra)
        {
            return await _listaCompraRepository.ActualizarAsync(
                id,
                listaCompra);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _listaCompraRepository.EliminarAsync(id);
        }
    }
}

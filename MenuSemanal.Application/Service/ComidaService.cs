using Dominio.Entidades;
using Infraestructura.AccesoDatos.Interfaces;

namespace Aplicacion.Service
{
    public class ComidaService
    {
        private readonly IComidaRepository _comidaRepository;

        public ComidaService(IComidaRepository comidaRepository)
        {
            _comidaRepository = comidaRepository;
        }

        public async Task<IEnumerable<Comida>> ObtenerTodasAsync()
        {
            return await _comidaRepository.ObtenerTodasAsync();
        }

        public async Task<Comida?> ObtenerPorIdAsync(int id)
        {
            return await _comidaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Comida> CrearAsync(Comida comida)
        {
            return await _comidaRepository.CrearAsync(comida);
        }

        public async Task<Comida?> ActualizarAsync(int id, Comida comida)
        {
            return await _comidaRepository.ActualizarAsync(id, comida);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _comidaRepository.EliminarAsync(id);
        }
    }
}
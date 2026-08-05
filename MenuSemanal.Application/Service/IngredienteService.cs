using Dominio.Entidades;
using Infraestructura.AccesoDatos.Interfaces;

namespace Aplicacion.Service
{
    public class IngredienteService
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredienteService(IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public async Task<IEnumerable<Ingrediente>> ObtenerTodosAsync()
        {
            return await _ingredienteRepository.ObtenerTodosAsync();
        }

        public async Task<Ingrediente?> ObtenerPorIdAsync(int id)
        {
            return await _ingredienteRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Ingrediente> CrearAsync(Ingrediente ingrediente)
        {
            return await _ingredienteRepository.CrearAsync(ingrediente);
        }

        public async Task<Ingrediente?> ActualizarAsync(int id, Ingrediente ingrediente)
        {
            return await _ingredienteRepository.ActualizarAsync(id, ingrediente);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _ingredienteRepository.EliminarAsync(id);
        }
    }
}
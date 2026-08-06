using Dominio.Entidades;
using Infraestructura.AccesoDatos.Interfaces;

namespace Aplicacion.Service
{
    public class MenuSemanalService
    {
        private readonly IMenuSemanalRepository _menuSemanalRepository;

        public MenuSemanalService(IMenuSemanalRepository menuSemanalRepository)
        {
            _menuSemanalRepository = menuSemanalRepository;
        }

        public async Task<IEnumerable<Dominio.Entidades.MenuSemanal>> ObtenerTodosAsync()
        {
            return await _menuSemanalRepository.ObtenerTodosAsync();
        }

        public async Task<Dominio.Entidades.MenuSemanal?> ObtenerPorIdAsync(int id)
        {
            return await _menuSemanalRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Dominio.Entidades.MenuSemanal> CrearAsync(
            Dominio.Entidades.MenuSemanal menuSemanal)
        {
            return await _menuSemanalRepository.CrearAsync(menuSemanal);
        }

        public async Task<Dominio.Entidades.MenuSemanal?> ActualizarAsync(
            int id,
            Dominio.Entidades.MenuSemanal menuSemanal)
        {
            return await _menuSemanalRepository.ActualizarAsync(id, menuSemanal);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _menuSemanalRepository.EliminarAsync(id);
        }
    }
}
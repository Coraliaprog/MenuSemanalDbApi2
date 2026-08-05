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

        public async Task<IEnumerable<MenuSemanal>> ObtenerTodosAsync()
        {
            return await _menuSemanalRepository.ObtenerTodosAsync();
        }

        public async Task<MenuSemanal?> ObtenerPorIdAsync(int id)
        {
            return await _menuSemanalRepository.ObtenerPorIdAsync(id);
        }

        public async Task<MenuSemanal> CrearAsync(MenuSemanal menuSemanal)
        {
            return await _menuSemanalRepository.CrearAsync(menuSemanal);
        }

        public async Task<MenuSemanal?> ActualizarAsync(int id, MenuSemanal menuSemanal)
        {
            return await _menuSemanalRepository.ActualizarAsync(id, menuSemanal);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _menuSemanalRepository.EliminarAsync(id);
        }
    }
}
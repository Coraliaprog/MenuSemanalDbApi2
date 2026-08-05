using Dominio.Entidades;


namespace Infraestructura.AccesoDatos.Interfaces
{
    public interface IMenuSemanalRepository
    {
        Task<IEnumerable<MenuSemanal>> ObtenerTodosAsync();

        Task<MenuSemanal?> ObtenerPorIdAsync(int id);

        Task<MenuSemanal> CrearAsync(MenuSemanal menuSemanal);

        Task<MenuSemanal?> ActualizarAsync(int id, MenuSemanal menuSemanal);

        Task<bool> EliminarAsync(int id);
    }
}
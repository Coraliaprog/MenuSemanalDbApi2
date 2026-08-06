using Dominio.Entidades;

namespace Infraestructura.AccesoDatos.Interfaces
{
    public interface IMenuSemanalRepository
    {
        Task<IEnumerable<Dominio.Entidades.MenuSemanal>> ObtenerTodosAsync();

        Task<Dominio.Entidades.MenuSemanal?> ObtenerPorIdAsync(int id);

        Task<Dominio.Entidades.MenuSemanal> CrearAsync(
            Dominio.Entidades.MenuSemanal menuSemanal);

        Task<Dominio.Entidades.MenuSemanal?> ActualizarAsync(
            int id,
            Dominio.Entidades.MenuSemanal menuSemanal);

        Task<bool> EliminarAsync(int id);
    }
}
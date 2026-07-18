using Dominio.Entidades;

namespace Infraestructura.AccesoDatos.Interfaces
{
    public interface IIngredienteRepository
    {
        Task<IEnumerable<Ingrediente>> ObtenerTodosAsync();

        Task<Ingrediente?> ObtenerPorIdAsync(int id);

        Task<Ingrediente> CrearAsync(Ingrediente ingrediente);

        Task<Ingrediente?> ActualizarAsync(int id, Ingrediente ingrediente);

        Task<bool> EliminarAsync(int id);
    }
}
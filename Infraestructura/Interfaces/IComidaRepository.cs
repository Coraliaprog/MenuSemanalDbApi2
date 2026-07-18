using Dominio.Entidades;

namespace Infraestructura.AccesoDatos.Interfaces
{
    public interface IComidaRepository
    {
        Task<IEnumerable<Comida>> ObtenerTodasAsync();

        Task<Comida?> ObtenerPorIdAsync(int id);

        Task<Comida> CrearAsync(Comida comida);

        Task<Comida?> ActualizarAsync(int id, Comida comida);

        Task<bool> EliminarAsync(int id);
    }
}
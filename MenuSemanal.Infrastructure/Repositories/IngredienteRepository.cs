using Dominio.Entidades;
using Infraestructura.AccesoDatos.Contexto;
using Infraestructura.AccesoDatos.Interfaces;
using Infraestructura.Core;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositories
{
    public class IngredienteRepository : BaseRepository<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(MenuSemanalDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Ingrediente>> ObtenerTodosAsync()
        {
            return await _context.Ingredientes
                .Include(i => i.Comida)
                .ToListAsync();
        }

        public async Task<Ingrediente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Ingredientes
                .Include(i => i.Comida)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Ingrediente> CrearAsync(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return ingrediente;
        }

        public async Task<Ingrediente?> ActualizarAsync(int id, Ingrediente ingrediente)
        {
            var ingredienteExistente = await _context.Ingredientes.FindAsync(id);

            if (ingredienteExistente == null)
            {
                return null;
            }

            ingredienteExistente.Nombre = ingrediente.Nombre;
            ingredienteExistente.Cantidad = ingrediente.Cantidad;
            ingredienteExistente.UnidadMedida = ingrediente.UnidadMedida;
            ingredienteExistente.ComidaId = ingrediente.ComidaId;

            await _context.SaveChangesAsync();

            return ingredienteExistente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);

            if (ingrediente == null)
            {
                return false;
            }

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
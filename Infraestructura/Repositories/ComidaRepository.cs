using Dominio.Entidades;
using Infraestructura.AccesoDatos.Contexto;
using Infraestructura.AccesoDatos.Interfaces;
using Infraestructura.Core;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositories
{
    public class ComidaRepository : BaseRepository<Comida>, IComidaRepository
    {
        public ComidaRepository(MenuSemanalDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Comida>> ObtenerTodasAsync()
        {
            return await _context.Comidas
                .Include(c => c.Ingredientes)
                .ToListAsync();
        }

        public async Task<Comida?> ObtenerPorIdAsync(int id)
        {
            return await _context.Comidas
                .Include(c => c.Ingredientes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comida> CrearAsync(Comida comida)
        {
            _context.Comidas.Add(comida);
            await _context.SaveChangesAsync();

            return comida;
        }

        public async Task<Comida?> ActualizarAsync(int id, Comida comida)
        {
            var comidaExistente = await _context.Comidas.FindAsync(id);

            if (comidaExistente == null)
            {
                return null;
            }

            comidaExistente.Nombre = comida.Nombre;
            comidaExistente.Descripcion = comida.Descripcion;
            comidaExistente.MenuSemanalId = comida.MenuSemanalId;

            await _context.SaveChangesAsync();

            return comidaExistente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var comida = await _context.Comidas.FindAsync(id);

            if (comida == null)
            {
                return false;
            }

            _context.Comidas.Remove(comida);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
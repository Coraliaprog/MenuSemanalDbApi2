using Dominio.Entidades;
using Infraestructura.AccesoDatos.Contexto;
using Infraestructura.AccesoDatos.Interfaces;
using Infraestructura.Core;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositories
{
    public class MenuSemanalRepository
        : BaseRepository<Dominio.Entidades.MenuSemanal>,
          IMenuSemanalRepository
    {
        public MenuSemanalRepository(MenuSemanalDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Dominio.Entidades.MenuSemanal>>
            ObtenerTodosAsync()
        {
            return await _dbSet
                .Include(m => m.Comidas)
                .ToListAsync();
        }

        public async Task<Dominio.Entidades.MenuSemanal?>
            ObtenerPorIdAsync(int id)
        {
            return await _dbSet
                .Include(m => m.Comidas)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Dominio.Entidades.MenuSemanal> CrearAsync(
            Dominio.Entidades.MenuSemanal menuSemanal)
        {
            await _dbSet.AddAsync(menuSemanal);

            await _context.SaveChangesAsync();

            return menuSemanal;
        }

        public async Task<Dominio.Entidades.MenuSemanal?> ActualizarAsync(
            int id,
            Dominio.Entidades.MenuSemanal menuSemanal)
        {
            var menuExistente =
                await _dbSet.FindAsync(id);

            if (menuExistente == null)
            {
                return null;
            }

            menuExistente.Nombre = menuSemanal.Nombre;
            menuExistente.FechaInicio = menuSemanal.FechaInicio;
            menuExistente.FechaFin = menuSemanal.FechaFin;

            await _context.SaveChangesAsync();

            return menuExistente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var menuSemanal =
                await _dbSet.FindAsync(id);

            if (menuSemanal == null)
            {
                return false;
            }

            _dbSet.Remove(menuSemanal);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
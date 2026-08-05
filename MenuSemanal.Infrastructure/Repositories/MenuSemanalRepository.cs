using Dominio.Entidades;
using Infraestructura.AccesoDatos.Contexto;
using Infraestructura.AccesoDatos.Interfaces;
using Infraestructura.Core;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Repositories
{
    public class MenuSemanalRepository : BaseRepository<MenuSemanal>, IMenuSemanalRepository
    {
        public MenuSemanalRepository(MenuSemanalDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<MenuSemanal>> ObtenerTodosAsync()
        {
            return await _context.MenusSemanales
                .Include(m => m.Comidas)
                .ToListAsync();
        }

        public async Task<MenuSemanal?> ObtenerPorIdAsync(int id)
        {
            return await _context.MenusSemanales
                .Include(m => m.Comidas)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MenuSemanal> CrearAsync(MenuSemanal menuSemanal)
        {
            _context.MenusSemanales.Add(menuSemanal);
            await _context.SaveChangesAsync();

            return menuSemanal;
        }

        public async Task<MenuSemanal?> ActualizarAsync(int id, MenuSemanal menuSemanal)
        {
            var menuExistente = await _context.MenusSemanales.FindAsync(id);

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
            var menuSemanal = await _context.MenusSemanales.FindAsync(id);

            if (menuSemanal == null)
            {
                return false;
            }

            _context.MenusSemanales.Remove(menuSemanal);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
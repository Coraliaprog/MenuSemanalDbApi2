using Infraestructura.AccesoDatos.Contexto;
using MenuSemanal.Domain.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Core
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly MenuSemanalDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(MenuSemanalDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
    }
}

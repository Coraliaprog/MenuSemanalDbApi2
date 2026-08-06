using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.AccesoDatos.Contexto
{
    public class MenuSemanalDbContext : DbContext
    {
        public MenuSemanalDbContext(
            DbContextOptions<MenuSemanalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dominio.Entidades.MenuSemanal> MenusSemanales { get; set; }

        public DbSet<Comida> Comidas { get; set; }

        public DbSet<Ingrediente> Ingredientes { get; set; }

        public DbSet<ListaCompra> ListasCompra { get; set; }
    }
}
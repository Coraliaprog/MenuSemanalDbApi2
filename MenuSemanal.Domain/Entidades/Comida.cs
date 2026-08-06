using MenuSemanal.Domain.Repository.Core;

namespace Dominio.Entidades
{
    public class Comida : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int MenuSemanalId { get; set; }

        public MenuSemanal? MenuSemanal { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
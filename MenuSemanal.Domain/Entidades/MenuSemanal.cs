using MenuSemanal.Domain.Repository.Core;

namespace Dominio.Entidades
{
    public class MenuSemanal : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public ICollection<Comida> Comidas { get; set; } = new List<Comida>();

        public MenuSemanal()
        {
        }

        public MenuSemanal(
            string nombre,
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
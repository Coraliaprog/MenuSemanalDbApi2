using MenuSemanal.Domain.Repository.Core;

namespace Dominio.Entidades
{
    public class Ingrediente : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public int ComidaId { get; set; }

        public Comida? Comida { get; set; }

        public Ingrediente()
        {
        }

        public Ingrediente(
            string nombre,
            decimal cantidad,
            string unidadMedida,
            int comidaId)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            UnidadMedida = unidadMedida;
            ComidaId = comidaId;
        }
    }
}
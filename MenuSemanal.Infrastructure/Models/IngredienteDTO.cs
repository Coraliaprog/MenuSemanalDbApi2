namespace Infraestructura.AccesoDatos.Models
{
    public class IngredienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public int ComidaId { get; set; }
    }
}

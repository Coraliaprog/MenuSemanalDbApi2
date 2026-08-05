namespace Infraestructura.AccesoDatos.Models
{
    public class ComidaDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public decimal PrecioEstimado { get; set; }
    }
}
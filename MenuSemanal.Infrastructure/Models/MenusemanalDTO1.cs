namespace Infraestructura.AccesoDatos.Models
{
    public class MenuSemanalDto
    {
        public int Id { get; set; }

        public string Dia { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public int ComidaId { get; set; }
    }
}
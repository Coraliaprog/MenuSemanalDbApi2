namespace Infraestructura.AccesoDatos.Models
{
    public class ListaCompraDto
    {
        public int Id { get; set; }

        public string Producto { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public bool Comprado { get; set; }
    }
}
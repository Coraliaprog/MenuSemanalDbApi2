using Dominio.Core;

namespace Dominio.Entidades
{
    public class ListaCompra : BaseEntity
    {
        public string Producto { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public bool Comprado { get; set; }
    }
}
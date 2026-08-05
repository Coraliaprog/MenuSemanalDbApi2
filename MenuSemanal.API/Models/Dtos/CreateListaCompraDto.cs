namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class CreateListaCompraDto
    {
        public string Producto { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public bool Comprado { get; set; }
    }
}
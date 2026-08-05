namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class CreateIngredienteDto
    {
        public string Nombre { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; } = string.Empty;

        public int ComidaId { get; set; }
    }
}
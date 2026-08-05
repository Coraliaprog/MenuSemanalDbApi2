namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class UpdateComidaDto
    {
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int MenuSemanalId { get; set; }
    }
}
namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class CreateComidaDto
    {
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int MenuSemanalId { get; set; }
    }
}
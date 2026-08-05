namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class CreateMenuSemanalDto
    {
        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
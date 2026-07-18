namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class UpdateMenuSemanalDto
    {
        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
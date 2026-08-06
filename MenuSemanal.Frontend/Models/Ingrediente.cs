using System.ComponentModel.DataAnnotations;

namespace MenuSemanal.Frontend.Models;

public class Ingrediente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(
        100,
        ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Range(
        typeof(decimal),
        "0.01",
        "999999",
        ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public decimal Cantidad { get; set; }

    [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
    public string UnidadMedida { get; set; } = string.Empty;

    [Range(
        1,
        int.MaxValue,
        ErrorMessage = "Debes seleccionar una comida.")]
    public int ComidaId { get; set; }
}
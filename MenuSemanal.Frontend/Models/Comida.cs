using System.ComponentModel.DataAnnotations;

namespace MenuSemanal.Frontend.Models;

public class Comida
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(
        100,
        ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(
        250,
        ErrorMessage = "La descripción no puede exceder 250 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    [Range(
        1,
        int.MaxValue,
        ErrorMessage = "Debes seleccionar un menú semanal.")]
    public int MenuSemanalId { get; set; }
}
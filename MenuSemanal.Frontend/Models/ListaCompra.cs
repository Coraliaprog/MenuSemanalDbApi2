using System.ComponentModel.DataAnnotations;

namespace MenuSemanal.Frontend.Models;

public class ListaCompra
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El producto es obligatorio.")]
    [StringLength(
        100,
        ErrorMessage = "El producto no puede exceder 100 caracteres.")]
    public string Producto { get; set; } = string.Empty;

    [Range(
        typeof(decimal),
        "0.01",
        "999999",
        ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public decimal Cantidad { get; set; }

    [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
    public string UnidadMedida { get; set; } = string.Empty;

    public bool Comprado { get; set; }
}
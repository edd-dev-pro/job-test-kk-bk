namespace VentasApi.Models;

public class Venta
{
    public int     Id        { get; set; }
    public string  Concepto  { get; set; } = null!;
    public decimal Monto     { get; set; }
    public DateTime Fecha    { get; set; } = DateTime.UtcNow;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

namespace VentasApi.Dtos
{
    public class VentaCreateDto
    {
        public string Concepto { get; set; } = null!;
        public decimal Monto { get; set; }
    }
}

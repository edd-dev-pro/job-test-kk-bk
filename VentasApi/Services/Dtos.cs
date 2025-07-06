namespace VentasApi.Services;

public record LoginDto(string Username, string Password);

public record VentaCreateDto(string Concepto, decimal Monto);

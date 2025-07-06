using Microsoft.EntityFrameworkCore;
using VentasApi.Models;

namespace VentasApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Venta> Ventas => Set<Venta>();
}

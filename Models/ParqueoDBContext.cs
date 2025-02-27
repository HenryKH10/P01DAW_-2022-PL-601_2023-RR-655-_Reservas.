using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class ParqueoDBContext : DbContext
    {
        public ParqueoDBContext(DbContextOptions<ParqueoDBContext> options) : base(options)
        {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<EspacioDeParqueo> EspaciosDeParqueo { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        }
    }
}
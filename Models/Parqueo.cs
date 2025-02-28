using System.ComponentModel.DataAnnotations;

namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class Parqueo
    {
        [Key]

        public int IdEspacio { get; set; }
        public int Numero { get; set; }
        public string Ubicacion { get; set; }
        public decimal CostoPorHora { get; set; }
        public string Estado { get; set; }
        public int IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}

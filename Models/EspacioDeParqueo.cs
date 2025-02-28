using System.ComponentModel.DataAnnotations;

namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class EspacioDeParqueo
    {
        [Key]
            public int Id { get; set; }
            public string Numero { get; set; }
            public string Ubicacion { get; set; }
            public decimal CostoPorHora { get; set; }
            public string Estado { get; set; } 
            public int SucursalId { get; set; }
            public Sucursal Sucursal { get; set; }
       

    }
}

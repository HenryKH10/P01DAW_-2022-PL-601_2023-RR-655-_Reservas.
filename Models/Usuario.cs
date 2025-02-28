using System.ComponentModel.DataAnnotations;

namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class Usuario
    {
        [Key]

        
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public string Contrasena { get; set; }
            public string Rol { get; set; }
            public ICollection<Reserva> Reservas { get; set; }
        }

    }
}

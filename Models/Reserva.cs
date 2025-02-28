using System.ComponentModel.DataAnnotations;

namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class Reserva
    {
        [Key]

            public int Id { get; set; }
            public int UsuarioId { get; set; }
            public Usuario Usuario { get; set; }
            public int EspacioId { get; set; }
            public EspacioDeParqueo Espacio { get; set; }
            public DateTime FechaReserva { get; set; }
            public int HorasReservadas { get; set; }
            public bool Activa { get; set; } 
        

    }
}


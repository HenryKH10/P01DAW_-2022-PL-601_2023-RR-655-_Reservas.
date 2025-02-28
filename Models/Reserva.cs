using System.ComponentModel.DataAnnotations;

namespace P01_2022_PL_601_2023_RR_655.Models
{
    public class Reserva
    {
        [Key]

        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspacio { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int CantidadHoras { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public Parqueo Parqueo { get; set; }
    }
}

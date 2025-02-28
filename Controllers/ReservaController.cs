using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_PL_601_2023_RR_655.Models;

namespace P01_2022_PL_601_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ParqueoDBContext _context;

        public ReservaController(ParqueoDBContext context)
        {
            _context = context;
        }

        // LEER TODAS LAS RESERVAS
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllReservas()
        {
            var listadoReservas = (from r in _context.Reservas
                                   select r).ToList();
            if (listadoReservas.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoReservas);
        }

        // BUSCAR RESERVA POR ID
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetReservaById(int id)
        {
            var reserva = (from r in _context.Reservas
                           where r.IdReserva == id
                           select r).FirstOrDefault();
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        // CREAR NUEVA RESERVA
        [HttpPost]
        [Route("Add")]
        public IActionResult AddReserva([FromBody] Reserva reserva)
        {
            try
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ACTUALIZAR RESERVA
        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateReserva(int id, [FromBody] Reserva reservaModificar)
        {
            var reservaActual = (from r in _context.Reservas
                                 where r.IdReserva == id
                                 select r).FirstOrDefault();

            if (reservaActual == null)
            {
                return NotFound();
            }

            reservaActual.FechaReserva = reservaModificar.FechaReserva;
            reservaActual.HoraInicio = reservaModificar.HoraInicio;
            reservaActual.CantidadHoras = reservaModificar.CantidadHoras;
            reservaActual.Estado = reservaModificar.Estado;
            reservaActual.IdUsuario = reservaModificar.IdUsuario;
            reservaActual.IdEspacio = reservaModificar.IdEspacio;

            _context.Entry(reservaActual).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(reservaModificar);
        }

        // ELIMINAR RESERVA
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteReserva(int id)
        {
            var reserva = (from r in _context.Reservas
                           where r.IdReserva == id
                           select r).FirstOrDefault();

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return Ok(reserva);
        }
    }
}

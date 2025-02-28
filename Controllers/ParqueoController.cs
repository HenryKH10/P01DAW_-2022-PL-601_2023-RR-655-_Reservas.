using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_PL_601_2023_RR_655.Models;

namespace P01_2022_PL_601_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueoController : ControllerBase
    {
        private readonly ParqueoDBContext _context;

        public ParqueoController(ParqueoDBContext context)
        {
            _context = context;
        }

        // LEER TODOS LOS PARQUEOS
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllParqueos()
        {
            var listadoParqueos = (from p in _context.Parqueos
                                   select p).ToList();
            if (listadoParqueos.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoParqueos);
        }

        // BUSCAR PARQUEO POR ID
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetParqueoById(int id)
        {
            var parqueo = (from p in _context.Parqueos
                           where p.IdEspacio == id
                           select p).FirstOrDefault();
            if (parqueo == null)
            {
                return NotFound();
            }
            return Ok(parqueo);
        }

        // CREAR NUEVO PARQUEO
        [HttpPost]
        [Route("Add")]
        public IActionResult AddParqueo([FromBody] Parqueo parqueo)
        {
            try
            {
                _context.Parqueos.Add(parqueo);
                _context.SaveChanges();
                return Ok(parqueo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ACTUALIZAR PARQUEO
        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateParqueo(int id, [FromBody] Parqueo parqueoModificar)
        {
            var parqueoActual = (from p in _context.Parqueos
                                 where p.IdEspacio == id
                                 select p).FirstOrDefault();

            if (parqueoActual == null)
            {
                return NotFound();
            }

            parqueoActual.Numero = parqueoModificar.Numero;
            parqueoActual.Ubicacion = parqueoModificar.Ubicacion;
            parqueoActual.CostoPorHora = parqueoModificar.CostoPorHora;
            parqueoActual.Estado = parqueoModificar.Estado;
            parqueoActual.IdSucursal = parqueoModificar.IdSucursal;

            _context.Entry(parqueoActual).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(parqueoModificar);
        }

        // ELIMINAR PARQUEO
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteParqueo(int id)
        {
            var parqueo = (from p in _context.Parqueos
                           where p.IdEspacio == id
                           select p).FirstOrDefault();

            if (parqueo == null)
            {
                return NotFound();
            }

            _context.Parqueos.Remove(parqueo);
            _context.SaveChanges();

            return Ok(parqueo);
        }
    }
}

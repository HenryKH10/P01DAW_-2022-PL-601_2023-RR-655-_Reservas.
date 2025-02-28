using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_PL_601_2023_RR_655.Models;

namespace P01_2022_PL_601_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ParqueoDBContext _context;

        public SucursalController(ParqueoDBContext context)
        {
            _context = context;
        }

        // LEER TODAS LAS SUCURSALES
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllSucursales()
        {
            var listadoSucursales = (from s in _context.Sucursales
                                     select s).ToList();
            if (listadoSucursales.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoSucursales);
        }

        // BUSCAR SUCURSAL POR ID
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetSucursalById(int id)
        {
            var sucursal = (from s in _context.Sucursales
                            where s.IdSucursal == id
                            select s).FirstOrDefault();
            if (sucursal == null)
            {
                return NotFound();
            }
            return Ok(sucursal);
        }

        // CREAR NUEVA SUCURSAL
        [HttpPost]
        [Route("Add")]
        public IActionResult AddSucursal([FromBody] Sucursal sucursal)
        {
            try
            {
                _context.Sucursales.Add(sucursal);
                _context.SaveChanges();
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ACTUALIZAR SUCURSAL
        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult UpdateSucursal(int id, [FromBody] Sucursal sucursalModificar)
        {
            var sucursalActual = (from s in _context.Sucursales
                                  where s.IdSucursal == id
                                  select s).FirstOrDefault();

            if (sucursalActual == null)
            {
                return NotFound();
            }

            sucursalActual.Nombre = sucursalModificar.Nombre;
            sucursalActual.Direccion = sucursalModificar.Direccion;
            sucursalActual.Telefono = sucursalModificar.Telefono;
            sucursalActual.NumeroEspacios = sucursalModificar.NumeroEspacios;

            _context.Entry(sucursalActual).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(sucursalModificar);
        }

        // ELIMINAR SUCURSAL
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteSucursal(int id)
        {
            var sucursal = (from s in _context.Sucursales
                            where s.IdSucursal == id
                            select s).FirstOrDefault();

            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursal);
            _context.SaveChanges();

            return Ok(sucursal);
        }
    }
}

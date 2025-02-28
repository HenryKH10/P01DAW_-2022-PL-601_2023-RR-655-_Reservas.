using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2022_PL_601_2023_RR_655.Models;

namespace P01_2022_PL_601_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ParqueoDBContext _context;

        public UsuarioController(ParqueoDBContext context)
        {
            _context = context;
        }

        // LEER TODOS LOS USUARIOS
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var listadoUsuarios = _context.Usuarios.ToList();
            if (listadoUsuarios.Count == 0)
            {
                return NotFound("No se encontraron usuarios.");
            }
            return Ok(listadoUsuarios);
        }

        // BUSCAR USUARIO POR ID
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado.");
            }
            return Ok(usuario);
        }

        // CREAR UN NUEVO USUARIO
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar el usuario: {ex.Message}");
            }
        }

        // ACTUALIZAR UN USUARIO
        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuarioModificar)
        {
            var usuarioActual = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioActual == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado.");
            }

            usuarioActual.Nombre = usuarioModificar.Nombre;
            usuarioActual.Correo = usuarioModificar.Correo;
            usuarioActual.Telefono = usuarioModificar.Telefono;
            usuarioActual.Contrasena = usuarioModificar.Contrasena;
            usuarioActual.Rol = usuarioModificar.Rol;

            _context.Entry(usuarioActual).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuarioModificar);
        }

        // ELIMINAR UN USUARIO
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado.");
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }

        // VALIDAR CREDENCIALES (USUARIO/CONTRASEÑA)
        [HttpPost]
        [Route("Login")]
        public IActionResult ValidarCredenciales([FromBody] LoginRequest loginRequest)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == loginRequest.Correo);
            if (usuario == null || usuario.Contrasena != loginRequest.Contrasena)
            {
                return Unauthorized("Credenciales inválidas.");
            }
            return Ok("Credenciales válidas.");
        }
    }

    // DTO para login
    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}

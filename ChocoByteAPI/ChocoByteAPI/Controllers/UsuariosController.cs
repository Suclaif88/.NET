using ChocoByteAPI.Data;
using ChocoByteAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace ChocoByteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        // GET api/usuarios/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> CreateUsuario(Usuario usuario)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Cedula == usuario.Cedula))
                return BadRequest("La cédula ya está registrada.");

            // Cifrado de la contraseña antes de almacenarla
            usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Cedula }, usuario);
        }

        // PUT api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Cedula)
                return BadRequest();

            var usuarioDb = await _context.Usuarios.FindAsync(id);
            if (usuarioDb == null)
                return NotFound();

            usuarioDb.Nombre = usuario.Nombre;
            usuarioDb.Apellido = usuario.Apellido;
            usuarioDb.Direccion = usuario.Direccion;
            usuarioDb.Telefono = usuario.Telefono;

            // Solo actualizar la contraseña si se proporciona
            if (!string.IsNullOrEmpty(usuario.Contrasena))
            {
                usuarioDb.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }



        // DELETE api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using ChocoByteAPI.Models;
using ChocoByteAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChocoByteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Registro de usuario
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Usuario usuario)
        {
            // Verificar si el usuario ya existe
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Cedula == usuario.Cedula);

            if (existingUser != null)
            {
                return BadRequest("El usuario ya existe.");
            }

            // Encriptar la contraseña
            usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);

            // Guardar el usuario en la base de datos
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuario registrado exitosamente.");
        }

        // Iniciar sesión y generar un token JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Cedula == model.Cedula);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(model.Contrasena, usuario.Contrasena))
            {
                return Unauthorized("Credenciales incorrectas.");
            }

            // Crear el token JWT
            var token = GenerateJwtToken(usuario);

            return Ok(new { Token = token });
        }

        // Método para generar el token JWT
        private string GenerateJwtToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.NameIdentifier, usuario.Cedula.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

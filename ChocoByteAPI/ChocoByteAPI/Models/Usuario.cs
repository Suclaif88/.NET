using System.ComponentModel.DataAnnotations;

namespace ChocoByteAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Cedula { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasena { get; set; }
    }
}

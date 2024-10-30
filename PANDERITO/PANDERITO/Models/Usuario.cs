using System.ComponentModel.DataAnnotations;

namespace PANDERITO.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone]
        public string Telefono { get; set; } = string.Empty;
    }
}

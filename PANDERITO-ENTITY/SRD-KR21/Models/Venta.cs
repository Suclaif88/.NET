using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagementApp.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Total { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }  // Cliente puede ser null

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}

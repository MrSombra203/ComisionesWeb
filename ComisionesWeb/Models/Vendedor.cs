
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionesWeb.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }
        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Apellido { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string Cedula { get; set; } = string.Empty;
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(20)]
        public string? Telefono { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionesWeb.Models
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        [Required]
        public int VendedorId { get; set; }
        [Required]
        public int ReglaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoVenta { get; set; }
        [StringLength(500)]
        public string? Descripcion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ComisionCalculada { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public Vendedor? Vendedor { get; set; }
        public Regla? Regla { get; set; }
    }
}

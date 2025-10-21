using System;
using System.ComponentModel.DataAnnotations;

namespace ComisionesWeb.ViewModels
{
    public class VentaCreateVM
    {
        [Required]
        public int VendedorId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; } = DateTime.Today;
        [Required, Range(0.01, 99999999)]
        public decimal MontoVenta { get; set; }
        [StringLength(500)]
        public string? Descripcion { get; set; }
    }
}
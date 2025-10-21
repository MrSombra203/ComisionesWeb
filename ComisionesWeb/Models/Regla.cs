using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionesWeb.Models
{
    [Table("Reglas")]
    public class Regla
    {
        [Key]
        public int ReglaId { get; set; }
        [Required, StringLength(100)]
        public string NombreRegla { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoMinimo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoMaximo { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeComision { get; set; }
        public bool Activa { get; set; } = true;
    }
}
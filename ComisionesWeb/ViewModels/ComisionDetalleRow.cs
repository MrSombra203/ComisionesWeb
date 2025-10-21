using System;

namespace ComisionesWeb.ViewModels
{
    public class ComisionDetalleRow
    {
        public int VentaId { get; set; }
        public string NombreVendedor { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime FechaVenta { get; set; }
        public decimal MontoVenta { get; set; }
        public string NombreRegla { get; set; } = string.Empty;
        public decimal PorcentajeComision { get; set; }
        public decimal? ComisionCalculada { get; set; }
        public string? Descripcion { get; set; }
    }
}

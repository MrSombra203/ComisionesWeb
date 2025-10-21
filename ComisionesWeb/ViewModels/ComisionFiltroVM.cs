using System;
using System.Collections.Generic;

namespace ComisionesWeb.ViewModels
{
    public class ComisionFiltroVM
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public IList<ComisionDetalleRow> Detalle { get; set; } = new List<ComisionDetalleRow>();
        public IList<ResumenComisionesRow> Resumen { get; set; } = new List<ResumenComisionesRow>();
    }
}
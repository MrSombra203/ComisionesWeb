
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Services
{
    public interface IComisionService
    {
        Task<IList<ComisionDetalleRow>> ObtenerDetalleAsync(DateTime inicio, DateTime fin);
        Task<IList<ResumenComisionesRow>> ObtenerResumenAsync(DateTime inicio, DateTime fin);
    }
}

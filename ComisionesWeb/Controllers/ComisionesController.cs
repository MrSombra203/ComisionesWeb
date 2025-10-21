using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ComisionesWeb.Services;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Controllers
{
    public class ComisionesController : Controller
    {
        private readonly IComisionService _svc;
        public ComisionesController(IComisionService svc) => _svc = svc;

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ComisionFiltroVM
            {
                FechaInicio = DateTime.Today.AddDays(-30),
                FechaFin = DateTime.Today
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ComisionFiltroVM vm)
        {
            if (!vm.FechaInicio.HasValue || !vm.FechaFin.HasValue)
            {
                ModelState.AddModelError(string.Empty, "Debes seleccionar un rango de fechas.");
                return View(vm);
            }
            if (vm.FechaInicio > vm.FechaFin)
            {
                ModelState.AddModelError(string.Empty, "La fecha de inicio no puede ser mayor que la fecha fin.");
                return View(vm);
            }

            vm.Detalle = await _svc.ObtenerDetalleAsync(vm.FechaInicio.Value, vm.FechaFin.Value);
            vm.Resumen = await _svc.ObtenerResumenAsync(vm.FechaInicio.Value, vm.FechaFin.Value);
            return View(vm);
        }
    }
}
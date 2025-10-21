using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ComisionesWeb.Data;
using ComisionesWeb.Services;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Controllers
{
    public class VentasController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IVentasService _ventasService;

        public VentasController(AppDbContext db, IVentasService ventasService)
        {
            _db = db;
            _ventasService = ventasService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vendedores = await _db.Vendedor
                .AsNoTracking()
                .Select(v => new SelectListItem
                {
                    Value = v.VendedorId.ToString(),
                    Text = v.Nombre + " " + v.Apellido
                })
                .ToListAsync();

            ViewBag.Vendedores = vendedores;
            return View(new VentaCreateVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(VentaCreateVM vm)
        {
            var vendedores = await _db.Vendedor
                .AsNoTracking()
                .Select(v => new SelectListItem
                {
                    Value = v.VendedorId.ToString(),
                    Text = v.Nombre + " " + v.Apellido
                })
                .ToListAsync();

            if (!ModelState.IsValid)
            {
                ViewBag.Vendedores = vendedores;
                return View(vm);
            }

            try
            {
                var id = await _ventasService.RegistrarVentaAsync(vm);
                TempData["Ok"] = $"Venta registrada (ID: {id}).";
                return RedirectToAction("Index", "Comisiones");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                ViewBag.Vendedores = vendedores;
                return View(vm);
            }
        }
    }
}
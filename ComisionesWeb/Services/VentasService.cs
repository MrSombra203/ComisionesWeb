using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ComisionesWeb.Data;
using ComisionesWeb.Models;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Services
{
    public class VentasService : IVentasService
    {
        private readonly AppDbContext _db;
        public VentasService(AppDbContext db) => _db = db;

        public async Task<int> RegistrarVentaAsync(VentaCreateVM vm)
        {
            var regla = await _db.Reglas
                .Where(r => r.Activa && vm.MontoVenta >= r.MontoMinimo && vm.MontoVenta <= r.MontoMaximo)
                .OrderByDescending(r => r.MontoMinimo)
                .FirstOrDefaultAsync();

            if (regla == null)
                throw new InvalidOperationException("No hay una Regla activa que cubra este monto.");

            var comision = Math.Round(vm.MontoVenta * (regla.PorcentajeComision / 100m), 2);

            var venta = new Venta
            {
                VendedorId = vm.VendedorId,
                ReglaId = regla.ReglaId,
                FechaVenta = vm.FechaVenta,
                MontoVenta = vm.MontoVenta,
                Descripcion = vm.Descripcion,
                ComisionCalculada = comision,
                FechaRegistro = DateTime.Now
            };

            _db.Ventas.Add(venta);
            await _db.SaveChangesAsync();

            return venta.VentaId;
        }
    }
}


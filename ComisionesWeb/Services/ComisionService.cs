
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComisionesWeb.Data;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Services
{
    public class ComisionService : IComisionService
    {
        private readonly AppDbContext _db;
        public ComisionService(AppDbContext db) => _db = db;

        public async Task<IList<ComisionDetalleRow>> ObtenerDetalleAsync(DateTime inicio, DateTime fin)
        {
            return await _db.ComisionDetalle
                .FromSqlInterpolated($"EXEC sp_ObtenerComisionesPorFecha {inicio}, {fin}")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<ResumenComisionesRow>> ObtenerResumenAsync(DateTime inicio, DateTime fin)
        {
            return await _db.ResumenComisiones
                .FromSqlInterpolated($"EXEC sp_ResumenComisionesPorVendedor {inicio}, {fin}")
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

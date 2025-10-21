using System.Threading.Tasks;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Services
{
    public interface IVentasService
    {
        Task<int> RegistrarVentaAsync(VentaCreateVM vm);
    }
}
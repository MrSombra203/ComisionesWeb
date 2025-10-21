
using Microsoft.AspNetCore.Mvc;

namespace ComisionesWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Privacy() => View();
    }
}
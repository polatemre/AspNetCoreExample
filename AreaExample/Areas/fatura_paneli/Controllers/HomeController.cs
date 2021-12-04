using Microsoft.AspNetCore.Mvc;

namespace AreaExample.Areas.fatura_paneli.Controllers
{
    [Area("fatura_paneli")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var data = TempData["data"];
            return View();
        }
    }
}

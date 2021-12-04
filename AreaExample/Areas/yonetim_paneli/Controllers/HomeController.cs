using Microsoft.AspNetCore.Mvc;

namespace AreaExample.Areas.yonetim_paneli.Controllers
{
    [Area("yonetim_paneli")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["data"] = "Sebepsiz boş yere ayrılacaksan...";
            return RedirectToAction("Index", "Home", new { area = "fatura_paneli" });
        }
    }
}

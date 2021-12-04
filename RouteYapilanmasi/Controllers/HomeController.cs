using Microsoft.AspNetCore.Mvc;
using RouteYapilanmasi.Models;
using System.Diagnostics;

namespace RouteYapilanmasi.Controllers
{
    // Bu attribute routing yapılanması genellikle api yapılanmalarında, konvasyonel olarak startup dosyasındaki route yapılanması ise mvc tarafında tercih edilmektedir.
    //[Route("[controller]/[action]")]
    //[Route("api/[action]")]
    [Route("api")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id, string x, int y)
        {
            return View();
        }

        [Route("in/{id:int?}")] // api/in şeklinde erişilebilir.
        public IActionResult Privacy(int? id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
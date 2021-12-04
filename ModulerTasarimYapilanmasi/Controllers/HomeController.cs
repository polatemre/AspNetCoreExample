using Microsoft.AspNetCore.Mvc;
using ModulerTasarimYapilanmasi.Models;
using System.Diagnostics;

namespace ModulerTasarimYapilanmasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            #region Controllerdan Layout ve Partialların datayı yakalaması için
            // Buradaki datayı partial view'ınde model olarak belirtirsek partial tarafından yakalanacaktır.
            //var images = new List<string> { "img1.jpg", "img2.jpg", "img3.jpg", "img4.jpg" };
            //return View(images);
            #endregion
            #region Controllerdan birden fazla data gönderip farklı partiallarda yakalamak.
            // Burada gönderdiğimiz datayı partial'da yakalamak için partiallın name kısmına yazmamız gerekiyor
            ViewBag.Data = new List<string> { "img1.jpg", "img2.jpg", "img3.jpg", "img4.jpg" };

            //Buradaki gönderdiğimiz object index.cshtml veya layout tarafından kullanılabilir.
            object o = new object();

            return View(o);
            #endregion

        }

        public IActionResult Privacy()
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
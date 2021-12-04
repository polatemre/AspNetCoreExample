using EnvironmentExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnvironmentExample.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment _webHostEnvironment;
        IConfiguration _configuration;

        public HomeController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            #region Docker Örneği
            // Mesaj isminde bir environment, appsettings, secrets değerimiz yok.
            // Bu değeri docker üzerinde environment olarak oluşturduğumuz taktirde değeri alabileceğiz.
            ViewBag.Mesaj = _configuration["Mesaj"];
            #endregion

            #region Environment Diğer appsettings ve secrets Dosyalarını Ezer
            // a değerini şu şekilde arayacaktır.
            // Environment Variables -> secrets.json -> appsettings.json
            // Environment secrets.json ve appsettings.json dosyalarını ezerler.
            var aDegeri = _configuration["a"];
            #endregion
            #region Hangi Environment'tayız Kontrolü
            ViewBag.Env = "";

            if (_webHostEnvironment.IsDevelopment())
            {
                ViewBag.Env = "Development";
            }
            else if (_webHostEnvironment.IsStaging())
            {
                ViewBag.Env = "Staging";
            }
            else if (_webHostEnvironment.IsProduction())
            {
                ViewBag.Env = "Production";
            }
            else if (_webHostEnvironment.IsEnvironment("Emre"))
            {
                ViewBag.Env = "Emre";
            }
            #endregion

            return View();
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
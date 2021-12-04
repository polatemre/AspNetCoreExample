using InversionOfControl.Models;
using InversionOfControl.Services;
using InversionOfControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InversionOfControl.Controllers
{
    public class HomeController : Controller
    {
        #region Container'da ki herhangi bir nesneyi talep ederken contoller bazlı talep.

        readonly ILog _log;

        public HomeController(ILog log)
        {
            _log = log;
        }
        public IActionResult Index()
        {
            // Böyle yapılmaz, bağımlı hale gelmiş oluruz, kaynak kodu değiştirmemiz gerekir...
            //TextLog textLog = new TextLog();
            //textLog.Log();

            _log.Log();
            return View();
        }
        #endregion

        #region Container'da ki herhangi bir nesneyi talep ederken action bazlı talep. Dependecy Injection
        public IActionResult Index([FromServices] ILog log)
        {
            // Böyle yapılmaz, bağımlı hale gelmiş oluruz, kaynak kodu değiştirmemiz gerekir...
            //TextLog textLog = new TextLog();
            //textLog.Log();

            _log.Log();
            return View();
        }
        #endregion


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
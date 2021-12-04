using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        // IConfiguration arayüzü nedir? :
        // Asp.NET Core IoC provider'ında bulunan bir servistir.
        // Bu servis uygulamadaki appsettings.json dosyasını okumakta ve içerisindeki value'ları bizlere getirmektedir. Dolayısıyla IoC'den bu servisi herhangi bir controller'da dependency injection ile talep edebilir ve appsetttings.json dosyasındaki konfigurasyonları kullanabiliriz.

        private readonly IConfiguration _configuration;
        private readonly MailInfo _mailInfo;

        public HomeController(IConfiguration configuration, IOptions<MailInfo> mailInfo)
        {
            _configuration = configuration;
            _mailInfo = mailInfo.Value;
        }

        #region Options Pattern ile Konfigurasyonları Dependecy Injection ile Yapılandırma
        // Options Pattern appsettings.json dosyasındaki konfigurasyonları Dependency Injection ile kullanmamızı sağlayan ve yapılandırılmış olan nesnel modellerle ilgili konfigurasyonları temsil etmemizi sağlayan bir tasarım desenidir.
        // Eğer appsettings'teki key değerleri değişirse her yerde değiştirmek durumunda kalmadan sadece model üzerinden değiştirerek temiz kod yazmış oluruz.
        // Bu neden options pattern kullanmamız daha doğru olacaktır.

        public IActionResult Index()
        {
            // Böyle uğraşmak yerine options pattern kullanırız.
            //string host = _configuration["MailInfo:Host"];
            //string port = _configuration["MailInfo:Port"];
            //string email = _configuration["MailInfo:EmailInfo:Email"];
            //string password = _configuration["MailInfo:EmailInfo:Password"];

            //Options pattern üzerinden:
            string host = _mailInfo.Host;
            string port = _mailInfo.Port;
            string email = _mailInfo.EmailInfo.Email;
            string password = _mailInfo.EmailInfo.Password;

            return View();
        }
        #endregion

        public IActionResult Privacy()
        {
            #region Indexer ile Veri Okuma
            // Değer odaklı çağırmadır, string döner.
            var v1 = _configuration["OrnekMetin"]; // türkçe karakter kullanmamalıyız
            var v2 = _configuration["Person"]; // null döner, obje
            var v3 = _configuration["Person:Name"];
            var v4 = _configuration["Logging:LogLevel:Default"];
            #endregion

            #region GetSection Metodu ile Veri Okuma
            // İstenilen alanı getirir, string getirme mecburiyeti yok. 
            var v6 = _configuration.GetSection("Person"); // null dönmez, alanı getirir.
            var v7 = _configuration.GetSection("Person:Name").Value; // string değeri elde ederiz.
            #endregion

            #region Get Metoduyla Verileri Uygun Nesneyle Eşleştirme
            var v8 = _configuration.GetSection("Person").Get(typeof(Person));
            #endregion

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
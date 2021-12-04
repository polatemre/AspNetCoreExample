using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// secrets.json dosyasının bulunduğu yer:
// C:\Users\emrep\AppData\Roaming\Microsoft\UserSecrets\

namespace SecretManagerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Index()
        { 
            var eposta = configuration["MailBilgileri:Eposta"];
            var sifre = configuration["MailBilgileri:Sifre"];

            #region SqlConnectionStringBuilder Sınıfı
            // appsettings.json'da bulunan ConnectionStrings'daki herkese açık server ve database bilgileri ile secret.json'daki username ve password hassas verilerini hızlıca birleştirmek için kullanılan bir sınıftır. Aksi halde + operatörleri gibi işlemler kullanarak birleştirecektik.

            var connection = configuration.GetConnectionString("SQL");
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connection);
            sqlConnectionStringBuilder.UserID = configuration["SQL:Username"];
            sqlConnectionStringBuilder.Password = configuration["SQL:Password"];

            var x = sqlConnectionStringBuilder.ConnectionString;

            #endregion
        }
    }
}

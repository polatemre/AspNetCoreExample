using Asp.NET_Core_Empty_to_MVC.Models;
using Asp.NET_Core_Empty_to_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Asp.NET_Core_Empty_to_MVC.Controllers
{
    //[NonController] --> Bu kullanımda controller olarak görülmeyecek ve içerisinde action metodu olsa da request'leri karşılayamayacaktır.
    public class ProductController : Controller
    {
        #region Action Türleri
        #region ViewResult
        //public IActionResult GetProducts()
        //{
        //    //Product product = new Product();
        //    ViewResult result = View(); // --> İlgili action ismiyle birebir aynı olan viewi tetikler.
        //    ViewResult result2 = View("Ahmet"); // -> Belirtilen view ismindeki view dosyasını render eder.
        //    return result2;
        //    //return View();
        //}
        #endregion

        #region PartialViewResult
        //// Yine bir View dosyasını(.cshtml) render etmemizi sağlayan bir action türüdür.
        //// ViewResult'dan temel farkı, client tabanlı yapılan Ajax isteklerinde kullanıma yatkın olmasıdır. Sayfada git gel yapmadan client tarafında işlem yaparken kullanılabilir.
        //// Teknik fark ise ViewResult _ViewStart.cshtml (Layout) dosyasını baz alır. Lakin PartialViewResult ise ilgili dosyayı baz almadan render edilir. (sadece belli bir bölümünü)
        //public PartialViewResult GetProducts()
        //{
        //    PartialViewResult result = PartialView();
        //    return result;
        //}
        #endregion

        #region JsonResult
        //// Üretilen datayı JSON türüne dönüştürüp döndüren bir action türüdür.
        //// Ajax tabanlı, client tabanlı işlemlerde tercih edilir.
        //public JsonResult GetProducts()
        //{
        //    JsonResult result = Json(new Product()
        //    {
        //        Id = 1,
        //        ProductName = "Terlik",
        //        Quantity = 1
        //    });

        //    return result;
        //}
        #endregion

        #region EmptyResult
        //// Bazen gelen istekler neticesinde herhangi bir şey döndürmek istmeyebiliriz. Böyle bir durumda EmptyResult action türü kullanılabilir.
        //// Response vardır, başarılı dönecektir ama result göndermeyecektir. Yani boştur.
        //public EmptyResult GetProducts()
        //{
        //    return new EmptyResult();
        //}
        //// void keywordünü de kullanabiliriz.
        ////public void GetProducts()
        ////{
        ////    return;
        ////}
        #endregion

        #region ContentResult
        //// İstek neticesinde cevap olarak metinsel bir değer döndürmemizi sağlayan action türüdür.
        //// Ajax tabanlı, client tabanlı işlemlerde tercih edilir. HTML kodları render edilmez.
        //public ContentResult GetProducts()
        //{
        //    ContentResult result = Content("Sebepsiz boş yere ayrılacaksan...");
        //    return result;
        //}
        #endregion

        #region ViewComponentResult
        //// İsteğe bağlı olarak bir ViewComponent render etmemizi sağlyan action türüdür.
        //// Modüler tasarım yapılanması başlığında ne olduğunu daha detaylı inceleyeceğiz.
        #endregion

        #region ActionResult
        //// Bütün result türlerinin base classıdır. Tüm action türlerini karşılayan ana türdür.
        //// Gelen bir istek neticesinde geriye döndürülecek action türleri değişkenlik gösterebildiği durumlarda kullanılan bir action türüdür.
        //public ActionResult GetProducts()
        //{
        //    if (true)
        //    {
        //        //....
        //        return Json(new object());
        //    }
        //    else if (true)
        //    {
        //        return Content("asdasd");
        //    }

        //    return View();
        //}
        #endregion

        #region IActionResult
        //// ActionResult'un interface'idir.
        //public IActionResult GetProducts()
        //{
        //    return View();
        //}
        #endregion
        #endregion

        #region NonAction ve NonController Attribute'ları
        //// Controller'ların içerisinde kesinlikle iş mantıkları olmamalıdır, ideal tasarım budur.
        //// İş mantıkları başka sınıflarda, katmanlarda, servislerde, API'lerde olmalıdır. Controller bunları tetikler, yönlendirir.
        //// Controller, kontrol edendir, iş yapan değildir.
        //// Ancak controller'da iş yapacak bir tasarımda çalışıyorsak iş yapan metodun action olarak görülmemesi için bu attribute'leri kullanmalıyız.
        //// Controller içerisinde NonAction attribute'u ile işaretlenen fonksiyonlar dışarıdan request karşılamazlar.
        //// Sadece algoritma barındıran/iş mantığı yürüren bir metottur.

        //public IActionResult Index()
        //{
        //    X();
        //    return View();
        //}

        //[NonAction]
        //public void X()
        //{
        //    // İş kodları...
        //}
        #endregion

        #region Birden Fazle Nesneyi View'e Gönderme / Tuple & ViewModel
        // Elimizdeki birden fazla nesneyi view'e göndermek için 2 yöntemimiz var. 1-Tuple, 2-ViewModel.
        #region ViewModel
        //public IActionResult TupleExample()
        //{
        //    Product product = new Product
        //    {
        //        ProductName = "A Product",
        //        Quantity = 10
        //    };

        //    User user = new User
        //    {
        //        Id = 1,
        //        Name = "Emre",
        //        LastName = "Polat"
        //    };


        //    UserProduct userProduct = new UserProduct
        //    {
        //        User = user,
        //        Product = product
        //    };

        //    return View(userProduct);
        //}
        #endregion
        #region Tuple Nesne Post Etme ve Yakalama
        // Eğer ki bind mekanizmasında tuple türde bir nesne kullanıyorsak bu tuple nesnenin içerisindeki değerler oluşturulup verilmesi gerekmektedir.
        public IActionResult TupleExample()
        {
            //Product product = new Product
            //{
            //    ProductName = "A Product",
            //    Quantity = 10
            //};

            //User user = new User
            //{
            //    Id = 1,
            //    Name = "Emre",
            //    LastName = "Polat"
            //};
            //var userProduct = (product, user);
            var userProduct = (new Product(), new User()); // null olmaması için göndermemiz gerekmekte.
            return View(userProduct);
        }

        // Post edilen tuple nesnesinin yakalanması
        [HttpPost]
        public IActionResult TupleExample([Bind(Prefix = "Item1")] Product product, [Bind(Prefix = "Item2")] User user)
        {
            return View();
        }
        #endregion
        #endregion

        #region Model Bazlı Veri Gönderimi & Veri Taşıma Kontrolleri
        //public IActionResult Index()
        //{
        //    var products = new List<Product>
        //    {
        //        new Product{ ProductName= "A Product", Quantity = 10 },
        //        new Product{ ProductName= "B Product", Quantity = 15 },
        //        new Product{ ProductName= "C Product", Quantity = 20 }
        //    };

        //    #region Model Bazlı Veri Gönderimi
        //    //return View(products);
        //    #endregion
        //    #region Veri Taşıma Kontrolleri
        //    // ViewBag dynamic olarak veriyi taşırken; ViewData ve TempData boxing işlemine tabii tutuyor yani object olarak veriyi taşıyor (bu nedenle ilgili view'de unboxing işlemi yapmamız gerekir)
        //    // TempData'nın önemli bir özelliği taşıdığı verileri farklı actionlara da yönlendirme neticesinde taşır.
        //    #region ViewBag
        //    // View'e gönderilecek/taşınacak datayı dynamic şekilde tanımlanan bir değişkenle taşımamızı sağlayan bir veri taşıma kontrolüdür.
        //    ViewBag.products = products;
        //    #endregion
        //    #region ViewData
        //    // ViewBag'de olduğu gibi actiondaki datayı view'e taşımamızı sağlayan bir kontroldür.
        //    // Ancak ViewBag'den farkı: ViewData boxing işlemi yaparak veriyi taşır. Bu yüzden view'de unboxing yapıp kullanmamız gerekecektir.
        //    ViewData["products"] = products;
        //    #endregion
        //    #region TempData
        //    // ViewData'da olduğu gibi actiondaki datayı view'e taşımamızı sağlayan bir kontroldür.
        //    // Ancak verileri cookie üzerinden taşır.
        //    // Bir action'da elde ettiğimiz verileri başka bir action'a taşımak istiyorsak TempData kullanmamız gerekecektir.
        //    // Complex Type'ları stringe dönüştürmeden view'e gönderirsek hata verecektir.
        //    string _products = JsonSerializer.Serialize(products);
        //    TempData["products"] = _products;

        //    return RedirectToAction("Index2");
        //    #endregion
        //    #endregion

        //    return View();
        //}

        //public IActionResult Index2()
        //{
        //    var v1 = ViewBag.products;
        //    var v2 = ViewData["products"];

        //    // Serialize edilmiş veriyi(string veri) tekrardan Deserialize(Json'a çevirme) etmemiz gerekmektedir.
        //    var _products = TempData["products"].ToString();
        //    List<Product> products = JsonSerializer.Deserialize<List<Product>>(_products);
        //    return View();
        //}

        //public IActionResult GetProducts()
        //{
        //    ViewBag.Mesaj = "Merhaba";
        //    User u = new User()
        //    {
        //        Name = "Emre Polat"
        //    };
        //    return View(u);
        //}
        #endregion

        #region Kullanıcıdan Veri Alma Yöntemleri
        #region Form Üzerinden Model Binding ile Veri Alma
        //public IActionResult CreateProduct()
        //{
        //    // Buradan gönderdiğimiz product nesnesi form'daki ilgili inputlara yerleştirilecek. İlgili form'da güncelleme yapılıp geri döndürülebilir. Güncelleme işlemlerinde kullanılabilir.
        //    var product = new Product()
        //    {
        //        ProductName = "B Product",
        //        Quantity = 25
        //    };
        //    return View(product);
        //}

        //// Bu şekilde yapmak yerine kullanıcan gelecek verileri model ile karşılamak gerekir.
        ////[HttpPost]
        ////public IActionResult CreateProduct(string txtProductName, string txtQuantity)
        ////{
        ////    return View();
        ////}

        //// Form içerisindei input nesneleri post edildiğinde bu nesnelere karşılık gelen propertyleri barındıran bir nesneyle otomatik olarak bind edilirler.
        //[HttpPost]
        //public IActionResult CreateProduct(Product product)
        //{
        //    return View();
        //}
        #endregion
        #region QueryString Üzerinden Veri Alma
        //public class QueryData
        //{
        //    public int A { get; set; }
        //    public string B { get; set; }
        //}

        //// URL üzerinden gönderilen ?a=1&b=asdf gibi veriler parametre üzerinden yakalanıp metot içerisinde kullanılabilir.
        //public IActionResult QueryString(string a, string b)
        //{
        //    return View();
        //}

        //// Parametreye belirtmeden metot içerisinde requst bilgilerinden QueryString bilgilerine erişilebilir.
        //public IActionResult QueryString2()
        //{
        //    // Requst yapılan endpoint'e QueryString paramatresi eklenmiş mi bunu kontrol eder.
        //    var queryString = Request.QueryString;
        //    var a = Request.Query["a"].ToString();
        //    var b = Request.Query["b"].ToString();
        //    return View();
        //}

        //// Model binding kullanarak QueryString. QueryString'e karşılık gelen uygun propertylere eşleştiriliyor.
        //public IActionResult QueryString3(QueryData data)
        //{
        //    return View();
        //}
        #endregion
        #region Route Parameter Üzerinden Veri Alma
        //// QueryString: 	    /user?name=max
        //// Route Parameter:  /user/max
        //// Bu biraz olsun güvenlik sağlıyor çünkü name parametresini gizlemiş oluyoruz.
        //// product/verial/5

        //public class RouteData
        //{
        //    public string A { get; set; }
        //    public string B { get; set; }
        //    public string Id { get; set; }
        //}

        //public IActionResult VeriAl(object id)
        //{

        //    return View();
        //}

        //// Request üzerinden route değerlerini alma
        //public IActionResult VeriAl2()
        //{
        //    var values = Request.RouteValues;
        //    return View();
        //}

        ////Herhangi bir tür ile de gelecek route parametreleri yakalanabilir.
        //public IActionResult VeriAl3(RouteData routeData)
        //{

        //    return View();
        //}

        //// Farklı bir route tanımlanması ile aynı şekilde alabiliyoruz.
        //// Burada parametre sırası önemli değildir ancak link üzerinde tanımlanan route sıralamasına uygun olarak girilmelidir.
        //public IActionResult VeriAl4(string id, string a, string b)
        //{
        //    return View();
        //}
        #endregion
        #region Headers Üzerinden Veri Alma
        // Postman ile istekte bulunurken header kısmına yazdığımız verileri Request'ten yakalayabilmekteyiz.
        //public IActionResult VeriAl()
        //{
        //    var headers = Request.Headers.ToList();
        //    return View();
        //}
        #endregion
        #region Ajax Tabanlı Veri Alma
        //// Client tabanlı istek yapmamızı sağlayan ve bu isteklerin sonucu almamızı sağlayan JavaScript tabanlı bir mimaridir.
        //public class AjaxData
        //{
        //    public string A { get; set; }
        //    public string B { get; set; }
        //}

        //// Gelen JSON verisini MVC mimarimiz otomatik olarak ilgili türe dönüştürüyor.
        //[HttpPost]
        //public IActionResult Ajax(AjaxData ajaxData)
        //{
        //    return View();
        //}
        #endregion
        #endregion

        #region Validation
        #region DataAnnotations
        //public IActionResult ValidationExample()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult ValidationExample(Product product)
        //{
        //    // ModelState: MVC'de bir type'ın data annotationslarının durumunu kontrol eden ve geriye sonuç döndüren bir proprtydir.
        //    if (!ModelState.IsValid)
        //    {
        //        //Loglama
        //        //Kullanıcı bilgilendirme

        //        //Hata Mesajını yakalamak, tabi bunu view üzerinde tagHelper ile yaparak view'de hata mesajını gösterebiliriz.
        //        //ViewBag.HataMesaj = ModelState.Values.FirstOrDefault(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
        //        //return View();
        //        var messages = ModelState.ToList(); // valid ve invalid olanları listeler.

        //        return View(product); // gelen model'ı yeniden view'e göndererek hata mesajlarını kullanıcıya gösterebiliriz.
        //    }

        //    // işleme/operasyona/algoritmaya tabii tutulur.
        //    return View();
        //}
        #endregion
        #region ModelMetadataType ile Validation Sorumluluğunu Başka Bir Sınıfa Yükleme

        #endregion
        #region FluentValidation Kütüphanesi ile Validation İşlemleri

        #endregion
        #region Server'da ki Validation'ları Dinamik olarak Client Tabanlı Uygulamak

        #endregion
        #endregion

        #region Layout
        public IActionResult Index2()
        {
            return View();
        }
        #endregion
    }
}

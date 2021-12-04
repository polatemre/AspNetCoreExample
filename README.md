Asp.NET Giriş:
- Asp.NET: Micrososft tarafından geliştirilmiş bir Web Uygulama Geliştirme mimarisidir.
- Asp.NET Core: Microsoft tarafından geliştirilen ücretsiz ve açık kaynak Web Geliştirme mimarisidir. Asp.NET'in halefidir. Windows, linux, mac.. çalışır. Tüm Asp.NET altyapısı yeniden tasarlanmıştır.
- Asp.NET Core ile gelen yenilikler: Daha performanslı, cross platform, modüler altyapı, dependency injection, asenkron işlemler, kolay bakım, razor pages



İnternetin Mantığı:
- Biz tıkladım, girdim, site açıldı yerine; istek(request) gönderdim, cevap(response) aldım şeklinde söyleyeceğiz.
- Backend(Server Side) veriyi üretir, frontend(client side) üretilmiş veriyi sunar.



Sunucu Çeşitleri:
- IIS(Internet Information Services): Asp.NET Core dahil olmak üzere web uygulamalarını barındırmak için esnek, güvenli ve yönetilebilir bir Web Sunucusudur.
- Kestrel: Asp.NET Core uygulamalarında dahili olarak gelen bir web sunucusudur.
- Nginx: Linux sistemlerde Asp.NET Core uygulamalarını çalıştırabilmemizi sağlayan bir sunucudur. Reverse Proxy olarak Asp.NET Core uygulamalarındaki dahili sunucuyla(Kestrel) işlevsellik gösterir.
- Apache: Linux vs. gibi ortamlarda Apache ile Asp.NET Core uygulamalarını ayağa kaldırabilirsiniz.
- Docker: Yazılım geliştiriciler ve sistem yöneticileri için geliştirilmiş açık kaynak olan bir yeni nesil sanallaştırma platformudur. Kendi başına bir sunucu değil bir sanallaştırma platformudur. Kendi içerisine bir sunucu kurup uygulamamızı ayağa kaldırabiliyoruz. Çalıştığımız platformdan bağımsız bir şekilde farklı sunucular tercih edebiliyoruz.
- HTTP.sys: Yalnızca Windows üzerinde çalışan Asp.NET Core için bir web sunucudur. Kestrel'in bir alternatifidir.



Web Uygulaması Geliştirme Yaklaşımları:

Olay Tabanlı Web Geliştirme Mimarisi(Event Driven Programming):
- Programın akışını kullanıcı eylemlerine göre yönlendiren programlama yaklaşımıdır. Örn: Lambanın botonuna basıldığında ışığı aç.
- Olaylar tanımlanır ardından o olaylar gerçekeştiğinde tetiklenir.
- Uygulama hızlı bir şekilde inşa edilebilir. Lakin bakım ve sonraki gelişim süreci oldukça maliyetli olduğu için günümüzde pek tercih edilmez.

MVC Mimarisi:
- MVC aslında bir design patterndir. 
- Asp.NET bu tasarım deseninin üzerine oturtulmuş bir mimari bize sunmaktadır.
- Üretilen veri ile gösterim arasında bir soyutlama esas alınmıştır.
- Model: Veritabanı işlemlerini yaptığımız katman.
- View: Görsellik, sunum işlemlerini yaptığımız katman.
- Controller: İstekleri karşılayan, model ile view arasında köprüsel işlemlerin üstlenildiği bir katmandır.
- Özet: Kullanıcı web sitesine istek gönderdiği zaman controller tarafından karşılanır. Eğer veritabanı işlemi varsa model'a gider. Ardından elde ettiği veriyi view'e gönderir. View'de html, css, js olarak basar.
- Asp.NET Core yapılanmasında API ile MVC tasarımı birleştirilmiştir. Yani aynı altyapıda çalıştırılmaktadır.
- MVC Microsoft tarafından üretilmiş değildir.

API Mimarisi (Application Programming Interface):
- Direkt olarka Web Uygulaması yaklaşımıdır diyemeyiz. Lakin genellikle web tabanlı uygulamalarda client ve server arasındaki iletişimi sağlayan bir sözleşme(Entity) olarak kullanılmaktadır. Bu forma Web API ismi verilmektedir.
- IoT temelleri buradan gelir.



Dosya Yapısı:

Program.cs:
- Asp.NET Core uygulaması özünde bir console uygulamasıdır.
- Bu console yapılandırılmış varsayılanlarla web barındırıcısı oluşturmak için bir metod çağırıyor. (CreateHostBuilder)
- Asp.NET Core kendi dahilinde sunucu barındırır demiştik. İşte o sunucuyu ayağa kaldırdığı nokta bu Program.cs dosyasıdır.
- Kestrel sunucusunu ayağa kaldırmak için CreateHostBuilder metodunu tetikletiyor.
- Host ayağa kaldırılırken belirli konfigurasyonlar gerekir, işte bu konfigurasyonlar Startup.cs dosyasında bildirilir.
- Startup.cs temel konfigurasyon sınıfımızdır.

Startup.cs:
- Web uygulamasında belirli konfigurasyonları yaptığımız dosyadır. İsmini değiştirebiliriz.
- ConfigureServices(Servis Konfigurasyonu): Bu uygulamada kullanılacak servislerin eklendiği/konfigure edildiği metottur. Asp.NET Core modüler bir yapıya sahip (parça bütün ilişkisi, istediğimizi ekleyip çıkarabilme kolaylığı). Servisler, belirli işlere odaklanmış ve o işin sorumluluğunu üstlenmiş kütüphaneler/sınıflar vs. servis = modül = kütüphane
- Configure(Konfigurasyon): Bu metota da uygulamada kullanılacak middleware/ara yazılımları çağırmaktayız.

appsettings.json:
- Uygulamada belirli statik değerleri tuttuğumuz bir konfigurasyon dosyası.
- Yazılımlarda bazen uygulamanın her yerinde kullanmak isteyebileceğimiz metinsel değerler olabilir (örn:ConnectionString)
- Yazılımlarda kullanılması gereken statik olan metinsel değerler kodun içerisinde yerleştirilmez. Çünkü gün gelir bu değer değiştirilmesi gerekirse eğer kodda her yerin düzeltilmesi gerekecektir. Bu durum maliyetli olacaktır. Bu maliyetten kaçınmak için statik olan değerleri appsettings.json dosyasında tutmaktayız.



MVC(Model-View-Controller):
- Mimarisel Desendir (Architectural Pattern)
- Mimarisel desenler, tasarım desenlerinden daha geniş kapsamlıdır. İçinde farklı tasarım desenleri(Observer, Decorator) bulunur. Belli bir mimarinin oturduğu desenlerdir. Tasarım desenleri belirli senaryolara uygun yerleştirilirken, mimarisel desenler ise genel yaklaşımımızı belirlerler.
- Microsoft bu desen üzerine oturtulmuş Asp.NET Core MVC mimarisini geliştirmişir.
- Model: Repository Design Pattern mi uygulayacaksın, Entity Framework Core, Entity Models, veritabanı işlemleri burada yapılır. İşlenecek veriyi temsil eden katmandır.
- View: İstek neticesinde elde edilen verileri görselleştirecek, görsel çıktısını verecek katmandır. HTML, CSS, JavaScript, Razor, Resim, Müzik, Video.
- Controller: Gelen request'leri karşılayacak olan ve request'in içeriğine göre gerekli model işlemlerini üstlenecek olan katmandır. Eğer model veya view'e gitme ihtiyacı yoksa controller model veya view'e gitmek zorunda değildir.
- Modelden direk view'e veri gitmez. Controller request'i karşılar modela gider, modelde veri üretilir controller'a geri gelir ardından controller'dan view'e gönderilir ve tekrardan view'den controller'a gönderilir ve response döner.

Boş Asp.NET Core uygulamasına MVC mimarisini ekleme işlemi:
- Startup.cs dosyasında ConfigureServices metoduna services.AddControllersWithViews(); eklenir. View ve controller servisi eklenmiş olur. Sadece controller istiyorsak AddControllers() yeterli olur. Böylece uygulama MVC davranışı sergileyebilecektir.
- Controllerı bulundurduğumuz klasorun ismi Controllers olmak zorunda değildir ancak bir standart haline gelmiştir. Aynı şekilde içindeki Controller sınıflarının ismi de HomeController tarzında olmak zorunda değildir. İstediğimiz ismi verebiliriz.
- Ancak view klasorleri Views klasoru altında ve controller'ın isminde olmak zorundadır.
- Aynı şekilde view klasorunun içindeki cshtml dosyalarının ismi ilgili controller altındaki ilgili action ile aynı isimde olmak zorundadır.
- View dosyaları .cshtml uzantılı dosyalardır.
- cs + html = cshtml => Razor(Html içerisinde C# kodlarını çalıştırmamızı sağlayan bir teknolojidir)
- Razor sayesinde html ve cs kodlarını tek dosyada kullanabiliyoruz.
- View fonksiyonu bu actiona ait view(.cshtml) dosyasını tetikleyecek olan fonksiyondur.
- Models klasorunun ismi Models olmak zorunda değildir ancak bir standart olduğu için Models deriz.



UrlHelpers Fonksiyonları: Asp.Net Core MVC uygulamalarında url oluşturmak için yardımcı metotlar içeren ve o anki url'e dair bizlere bilgi veren bir sınıftır
Metotlar
- Action: Verilen Controller ve Action'a ait url oluşturmayı sağlayan metottur. Verdiğimiz route konfigurasyonuna göre oluşturur. Örn: Url.Action("index", "product", new{ id = 5}) -> /product/index/5
- ActionLink: Action ile aynı özellik ancak host kısmını başına ekler. Örn: Url.ActionLink("index", "product", new{ id = 5}) -> https://localhost:5001/product/index/5
- Content: Pek kullanmayız. UseStaticFiles middleware'ı ile gelen static dosya yapılanması bu işlevselliği daha efektif üstlenmektedir.
- RouteUrl: Mimaride tanımlı olan Route isimlerine uygun bir şekilde url oluşturan bir metottur. Örn: Url.RouteUrl("Default") -> /Product/GetProducts
Property
- ActionContext: O anki url'e dair tüm bilgilere erişebilmemizi sağlayan bir property'dir.



HtmlHelpers Fonksiyonları: Günümüzde TagHelper'lar geldiği için tag oluşturma işinde pek kullanmayız. TagHelper'lar daha az maliyetlidir. HtmlHelper'lar sunucuya boşa yorar. 

Metotlar:
- Html.Partial: Hedef View'i render etmemizi sağlar.
- Html.RenderPartial: Hedef View'i render etmemizi sağlar. Html.RenderPartial sayfanın TextWriter'ını kullandığı için(yani Http response stream'e yazıldığı için) Html.Partial'a nazaran daha hızlı render işlemini yürütür. Dolayısıyla daha performanslıdır.
- Html.ActionLink: Url oluşturur. A taginde oluşturur.
- Html Form Metotları: Html Form ve input nesneleri oluşturmamızı sağlarlar. Maliyetlidir kullanılmaması gerekir. Bunun yerine TagHelper kullanmalıyız.

Propertyler: Kod üzerinde anlatıldı
- ViewContext: 
- TempData: 
- ViewData: 
- ViewBag: 



TagHelper Fonksiyonları: Daha okunabilir, anlaşılabilir ve kolay geliştirilebilir bir view inşa etmemizi sağlayan, Asp.NET Core ile birlikte HtmlHelpers'ların yerine gelen yapılardır.
- Viewlerde ki kod maliyetini oldukça düşürmektedir. Daha az kod yazmış oluruz.
- HtmlHelpers'ların html nesnelerinin generate edilmesini server'a yüklemesinin getirdiği maliyetide ortadan kaldırmaktadırlar.
- HtmlHelpers'lar da ki programatik yapılanma, programlama bilmeyen tasarımcıların çalışmasını imkansız hale getirmekteydi. TagHelpers ile buradaki kusur giderildi ve tasarımcılar açısından programlama bilgisine ihtiyaç duyulmaksızın çalışma yapılabilir nitelik kazandırdı.
- HtmlHelpers ile oluşturulan html nesnesinin attribute'ları 'htmlAttribute' parametresi üzerinden anonim nesne oluşturmakta. Bu durum hem bellek optimizasyonu açısından hemde kod maliyeti açısından oldukça zararlıdır. TagHelpers bu durumu ortadan kaldırmakta ve html nesnelerine sadece ilgili attribute'ları normal sözdizimiyle vermekle ilgilenmektedir.
- Bütün html taglerine uygun tag helper vardır. asp- dediğimizde gelirler.
- Cache kullanabilmekteyiz.
- Environment'a göre kod tetikleyebiliyoruz. Development, production, staging.
- RemoveTagHelper ile taghelperları kaldırabilmekteyiz.
- <!form> </!form> -> içerisindeki TagHelper'lar çalışmayacaktır.

Image TagHelper:
- Tarayıcılar static dosyaları local cache üzerinde saklamaktadırlar.
- Cachelenmiş bir dosya tekrar istenildiği taktirde bunun için server'a istek gönderilmez ve local cache üzerinden ilgili dosyanın cache'i gönderilir. Böylece sayfalar ilk açılışlarından sonraki taleplerde daha hızlı yüklenebilmektedirler.
- Lakin bazen dosya adı değişmeden içeriği değişebilmektedir. Böyle bir durumda ilgili dosyanın cache'den değil, server'dan yüklenmesi gerekmektedir. Bu durumda biz ETag yöntemiyle müdahele edebilmekteyiz.
- Asp.NET Core MVC mimarisinde TagHelper'lar içerisinde static dosyalara etag üzerinden bu değişikliği fark ederek ilgili dosyanın server'dan talep edileceği bilinmektedir. asp-append-version="true" eklendiğinde kaynakta değişim olduğunda talep edecektir.

Partial TagHelper:
- Partial view'ini render edebilmekte.



Model Binding: Http Request ile gelen verilerin ayrıştırılarak ilgili controller'da bulunan action metotlarında uygun herhangi bir türe dönüştürülmesi işlemidir.
- Örneğin formdan girilen inputları, class propertylerine bind edilmesi. Class propertylerine atanacaktır.
- Bir action metodu varsayılan olarak get'tir.
- Request neticesinde gelen dataların hepsi Action fonksiyonlarda parametrelerden yakalanmaktadır.



Kullanıcıdan Veri Alma Yöntemleri:
- Kullanıcıdan veri request ile alınabilir.

Formdan Üzerinden Veri Alma:
- IFormCollection: Herhangi bir sınıf oluşturmadan post edilen form nesnelerine erişebiliyoruz.

- Model binding: Formdan gönderilen input nesnelerindeki name ya da asp-for(render edildiğinde name'e dönüşür) değerlerine karşılık bir sınıf tanımlayıp onu instance'ındaki propertyler ile binding işlemi gerçekleştirebiliyoruz.
QueryString Üzerinden Veri Alma:

- QueryString: Güvenlik gerektirmeyen bilgilerin url üzerinde hızlı bir şekilde taşınması için kullanılan yapılanmadır.....com/sehir/ankara?ilce=2 -> ?ilce=2 (QueryString değeri)
- Sadece kullanıcıdan değil yazılımsal operasyonlar neticesinde QueryString'e değerler koyabilir ve kullanabiliriz.
- QueryString yapılan requestin türü(get, set..) her ne olursa olsun QueryString değerleri taşınabilir. 

Route Parameter Üzerinden Veri Alma:
QueryString: 	/user?name=max
Route Parameter:/user/max
- Bu biraz olsun güvenlik sağlıyor çünkü name parametresini gizlemiş oluyoruz. 

Header Üzerinden Veri Alma:
- Kullanıcının göndermiş olduğu http request içerisinde bulunan kısımdır.
- Authorization, JWT'de header'a verileri koyup o şekilde yetkilendirmeleri sağlıyoruz.
- Postman ile header kısmına veri koyup request'te bulunabiliriz.

Ajax Tabanlı Veri Alma:
- Client tabanlı istek yapmamızı sağlayan ve bu isteklerin sonucu almamızı sağlayan JavaScript tabanlı bir mimaridir.



Kullanıcıdan Gelen Verilerin Doğrulanması - Validation:

Data Annotation ile Validation
- Validation paralel bir şekilde client ve server taraflarında uygulanmalıdır.
- Modelde data annotionsları kullanarak validation yapabiliriz.
- ModelState : MVC'de bir type'ın data annotationslarının durumunu kontrol eden ve geriye sonuç döndüren bir proprtydir.
- Data annotation'larda tek sorumluluk prensibine(Single Responsibilty Prenciple) aykırılık söz konusudur. Bunun için FluentValidation dediğimiz yapılanmayı ve ModelMetadataType tür ile validation sorumluluğunu başka sınıflara üstlenmeyi ve ileri seviye validation yapmalıyız.

ModelMetadataType ile Validation Sorumluluğunu Başka Bir Sınıfa Yükleme
- Kodda uyguladık.

FluentValidation Kütüphanesi ile Validation İşlemleri
- Validation uygularken bize efektiflik, kolaylık sağlar. SOLID prensiplerine uyar.
- Kütüphaneler gelip geçicidir önemli olan mimariye hakim olmaktır.

Server'da ki Validation'ları Dinamik olarak Client Tabanlı Uygulamak
- Kullanılacak 3 kütüphane: jQuery, jQuery Validate, jQuery Validation Unobtrusive
- Proje üzerine sağ tık > Add > Client-Side Library ile bütün UI kütüphanelerini projemize ekleyebiliriz.
- Bütün css, js, img dosyalarını wwwroot klasorune eklemek zorundayız.
- Kütüphaneleri script olarak view dosyamıza eklememiz gerekmektedir.



Layout:
- Views -> Shared -> _Layout.cshtml olarak tanımlanır. Standart haline geldiği için, genellikle böyledir. Ancak farklı dizinde ve isimde de tanımlanabilir.
- Tekrar eden yapılar Layout dosyasında yazılır. Header, footer gibi.

- RenderBody(): View'den view'e değişkenlik gösteren veriyi basmak için kullanılır. O anki render edilen View'in result'unu nereye basılacağını ifade eden fonksiyondur. 
- Bir Layout dosyasında sadece 1 tane RenderBody() tanımlaması yapılmak zorundadır. 1'den fazla tanımlanamaz.

- RenderSection("name"): Layout içerisinde isimsel alanlar tanımlamamızı sağlarlar. Sayfadan sayfaya fark edebilecek bir nokta tanımlıyabiliyoruz.
- RenderSection'a ilgili view'den değer gönderilmez ise hata verecektir. Eğer zoraki kullanılmasını istemiyorsak required parametresine false değeri vermemiz gerekir.
- JS referansları için kullanılabilir. Bazı view'ler için js kütüphanesi gerekiyor olabilir. Sadece o view'e JS kütüphanesi eklenir.

_ViewStart.cshtml:
- Asıl amacı tüm view'ler de kullanılması/yapılması gereken ortak çalışmaların yapıldığı view'dir.
- Tüm view'lerin atasıdır diyebiliriz.
- İlk önce bu view render edilir. Başlangıç view'idir.
- Her view'e etki eder.
- Views klasörü altında _ViewImport.cshtml olarak oluşturulması gerekir.
- Genellikle tüm view'lerin ortak kullanacağı Layout tanımlaması bu dosya içerisinde gerçekleştirilir.
- Eğer ki genelin dışında bir Layout tanımlayacaksak ilgili view'de kendimiz layout tanımlaması yapabiliriz. Yada null değerini verirsek hiç bir Layout kullanmayacaktır.

_ViewImports.cshtml:
- Razor sayfaları için kütüphane ve namespace tanımlamalarını sayfa sayfa farklı tanımlamaktansa ortak/merkezi olarak tanımlamamızı sağlayan bir dosyadır.
- Mimarideki bütün viewsler tarafından benimsenir.
- Views klasörü altında _ViewImports.cshtml isminde oluşturulmalıdır.
- VıewImports.cshtml dosyasında programatik tanımlamaları (using, namespace, imports işlemleri, taghelper lib) yaparız.
- ViewStart.cshtml dosyasında ise programatiğin dışında (layout, ortak kullanılan html tabanlı çalışmalar) olan çalışmaları yaparız.



Modüler Tasarım:
- Örneğin araba birden fazla parçalardan bir araya gelmiş bir bütündür. Arabanın tekerleği bozulunca motoru da bozulmaz.
- Single Responsibilty Principle tek sorumluluk prensibi bu açıdan önemlidir.
- PartialView ve ViewComponent ile MVC mimarisinde modüler bir yapılanma sağlayabiliriz.

PartialView: 
- Modüler tasarımda her bir modülün ayrı bir .cshtml olarak tasarlanmasını ve ihtiyaç doğrultusunda ilgili parçanın çağrılıp kullanılmasını sağlayan bir yöntemdir.
- Viewleri parçaladığımız modüllere nasıl veri gönderebiliyoruz? Controller'dan göndermemiz gerekiyor. Controllerdan View'e gönderilen data öncelikle Layout, ardından view ve partiallara tanışanacaktır. Viewler'de ya da Layout'ta olan Partial'lara, gönderdiğimiz data paylaşılacaktır. Yani gönderdiğimiz datalara hem layouttaki partiallar hem de view'de ki partiallar erişebilir olacaktır.
- Controllerden gönderilen farklı bir datayı viewler karşılamak istiyorsa 
- PartialView'ler ile layouttaki rendersection bölgesine değer göndermemiz yasaklanmıştır.

ViewComponent:
- PartialView yapılanması ihtiyacı olan dataları controller üzerinden elde edeceği için Controller'daki maliyeti arttırmakta ve SOLID prensiplerine aykırı davranılmasına sebebiyet verebilmektedir.
- PartialView yapısal olarak controller üzerinden beslenmektedir.
- Controllerdan partial'lara veri göndermek zahmetli olabilmektedir. Controllerda fazladan kod yazımı, controllerın amacı dışında kullanımına yol acabilmektedir.
- ViewComponent ise ihtiyacı olan dataları controller üzerinden değil direkt kendi cs dosyasından elde edebilmektedir. Böylece controllerdaki lüzumsuz maliyeti ortadan kaldırmış olmaktayız.
- View'in neresinde kullanıyorsan kullan kendi cs dosyasından veriyi çekip kullanabilmekteyiz
- Controllerdaki maliyet düşürülmüş olur.
- Controllerlardaki tek sorumluluk prensibini yerine getirmiş oluruz.
- ViewComponent hangi dataya ihtiyacı varsa onunla ilgili bir çalışma yapıyor, dolayısıyla ViewComponentlerin render edilme süreci daha hızlı olduğu söyleniyor.
- ViewComponent dependency injection mekanizması .cs dosyasında kullanabilir haldedir. ViewComponentı render ederken dependency injection constructor'ı üzerinden gerçekleştirebiliriz.
- Önce cs sonra cshtml dosyasını oluşturabiliriz.
- ViewComponentların .cs dosyası controller gibi çalışmaz, herhangi gelen isteği ViewComponentta karşılayamayız. Eğer böyle bir durumla karşılaştığımızda ViewComponent'ın view dosyasında bir form tasarladıysak bunu post neticesinde bir controller'a yönlendirmemiz gerekecektir.



Route:
- Gelecek olan isteğin hangi rotaya gideceğini belirlyen şablonlardır.
- UseRouting() middleware'i tetiklendiği zaman gelen requestteki rotaları ayırmakta ve ilgili rotaya karşılık gelen controller hangisi ise onu ayağa kaldırır ve gerekli action'ı tetikler.
- UseEndpoints middleware'i kendi içerisinde rotaları tutar ve tarif etmemizi sağlar. UseEndpoints içerisinde kendi custom rotalarımızı tanımlayabiliriz.

Custom Route Handler(Özelleştirilmiş Rota İşleme Operasyonu):
- Gelen istekleri controller dışında farklı handler sınıflarına yönlendirsek ve isteğe karşılık sonucu orada gerçekleştirip döndürme işlemi yapsak, controllerdan bağımsız işlem yapmamız gerekiyor. Klasik MVC'den çıkıp normal handler işlemi gerçekleştirmek istiyoruz.
- Herhangi bir belirlenmiş route şemasının controller sınıflarından ziyada business mantığında karşılanması ve orada iş görüp response'un dönülmesi operasyonudur.
- Örneğin image dosyası geldi formatlandırma işlemi yapmak istiyoruz bunun için controller'ı yormanın anlamı yok. İşte buradaki anlamsızlığı ortadan kaldırmak için Custom Route Handler yapısı inşa edilmiştir.
- Genel geçer operasyonlarda klasik controller mekanizmasıyla gelen requesti karşılayıp gerekli opersayonu gerçekleştireceksin.
- IDisposble'dan türüyen nesneler için using kullanıyoruz. Garbage collector fonksiyondan çıkıldığı zaman nesneyi imha edecektir.



MiddleWare:
- Clientten gelen request neticesinde response dönene kadar olacak işlerin, yapılacak işlemlerin sorumluluğunu üstlenecek olan ara yazılımlara denir.
- Web uygulamaasına client'tan gelen request'e karşılık verilecek response'a kadar arada farklı işlemler gerçekleştirmek ve sürecin gidişatına farklı yön vermek isteyebiliriz.
- Controller'dan önceki işlemler, controllerın devreye alınması, controllerdan sonra yapılacak işlemler vs. hepsi middleware yapılanması iledir.
- Sarmal bir şekilde tetiklenirler, recursive mantığı. Bir middleware bitmeden diğerine geçecektir. [[[]]]
- Configure metodu içerisinde middleware'ler çağrılır.
- Asp.NET Core mimarisinde tüm middleware'ler Use ile başlar.
- Middleware'lerde tetiklenme sırası önemlidir. Random sırada yazamayız.

Hazır Middleware'ler: Run, Use, Map, MapWhen
- Asp.NET Core'da kendi çekirdeğinde bulunan middleware'lerdir.
- Run: Kendisinden sonra gelen middleware'i tetiklemez. Dolayısıyla kullanıldığı yerden sonraki middleware'ler tetiklenmeyeceğinden dolayı akış kesilecektir. Bu etkiye Short Circuit(Kısa Devre) denir.
- Use: Run metoduna nazaran, devreye girdikten sonra süreçte sıradaki middleware'i çağırmakta ve normal middleware işlevi bittikten sonra geriye dönüp devam edebilen bir yapıya sahiptir.
- Map: Bazen Middleware'i talep gönderen path'e göre filtrelemek isteyebiliriz. Bunun için Use ya da Run fonksiyonlarında if kontrolü sağlayabilir yahut Map metodu ile daha profesyonel işlem yapabiliriz. Örn: /home path'ine gidilecekse şu middleware çalıştır.
- MapWhen: Map metodu ile sadece request'in yapıldığı path'e göre filtreleme yapılırken, MapWhen metodu ile gelen request'in herhangi bir özelliğine göre bir filtreleme işlemi gerçekleştirilebilir. Örn: Get isteği ise şu middleware çalıştır.



Dependency Injection Desgin Pattern & IoC(Inversion of Control) Desgin Pattern

Dependecy Inversion Principle: 
- Bağımlılıkların tersine çevrilmesi. Dependency Injection Design Pattern ile bu prensibi pratikte uygulamış oluyoruz.
- Dependency Injection Design Pattern: Bir sınıfta başka bir sınıfı new'liyorsak o newlediğimiz sınıfa bağımlı hale gelmiş oluruz, işte bunu mümkün olduğunca soyutlamaya, bağımlılığı azaltmaya yarayan bir design patterndir.
- Biz new ile o nesneyi bir sınıfta oluşturmak yerine parametre olarak o nesneyi alırsak, başka bir sınıfa bağlı olmamış oluruz.
- Sınıf içerisinde ihtiyaç olan nesnenin ya constructor'dan ya da setter metoduyla parametre olarak alınması gerektiğini savunur.
- Böylece her iki sınıfı birbirinden izole etmiş olduğumuzu savunmaktadır.

IoC (Inversion of Control):
- Sınıflarımızın bağımlılığını azaltmak için bağımlılıkları Dependency Injection ile dışarıdan alabiliriz demiştik.
- Ancak bazı durumlarda sınıfımız içerisinde çok sayıda arayüze referans vermemiz gerekebilir.
- Bu durumda her biri için dependency injection kodu yazmamız gerekecektir ki bu durum sonunda bir kod karmaşasına neden olacaktır.
- Bunun için bu işlemi otomatikleştirecek bir yapı kurmamız gerekecektir.
- Bu yapıya Inversion of Control denilir.
- Özünde dictionary bir koleksiyondur.
- Dependency Injection kullanılarak enjekte edilecek olan tüm değerler/nesneler IoC Container dediğimiz bir sınıfta tutulurlar. Ve ihtiyaç doğrultusunda bu değerler/nesneler çağırılarak elde edilirler.

Asp.NET Core'da IoC Yapılanması
- .NET uygulamalarında IoC yapılanmasını sağlyan third pary framworkler mevcuttur. Structuremap, Autofac, Ninject...
- Asp.NET Core mimarisi, bu third party kütüphaneler kadar yetenekli olmasa da içerisinde built-in olarak IoC Container modülü bulundurmaktadır.

Built-in Container
- Built-in IoC Container, içerisinde koyulacak değerleri/nesneleri üç farklı davranışla alabilmektedir.
- Singleton: Uygulama bazlı tekil nesne oluşturur. Tüm taleplere o nesneeyi gönderir.
- Scoped: Her request başına bir nesne üretir ve o request pipeline'nında olan tüm isteklere o nesneyi gönderir.
- Transient: Her request'in her talebine karşılık bir nesne üretir ve gönderir.



Areas Yapılanması:
- Bir web uygulamasında farklı işlevsellikleri ayırmak için kullanılan özelliklerdir.
- Bir web uygulaması arayüz ve yönetim panelinden oluşur. Genellikle bunları ayırmak için kullanabiliriz.
- Bu farklı işlevsellikler için farklı katmanda, bir route ayarlamamızı sağlayan ve bu katmanda o işleve özel yönetim sergileyen bir yapılanmadır.
- Her bir area, içerisinde View, Controller ve Model katmanı barındırabilir.
- Nerelerde kullanılabilir: Yönetim panelleri, faturalandırma sayfaları, istaksel paneller, işlevsel modüller, uygulamada mantıksal olarak ayrılabilen üst düzey işlevsel bileşenler...
- Area çok katmanlı mimari değildir.

Area Attribute: 
- Area içerisinde controller Area Attribute'u ile işaretlenmelidir.
- Böylece ilgili alanın uygulamadaki adı resmiyette belirtilmiş olacaktır.
- Aksi taktirde farklı area'larda ki controller'lardan aynı isimde olanları çakışma ihtimalleri vardır.

Area'ya Route Belirleme:
- Her bir area, içerisindeki controller'lara erişim için farklı bir route sağlamaktadır.
- Dolayısıyla bu route'ların tarafımızca tasarlanması gerekmektedir.
- Startup dosyasına UseEndPoint olarak eklenmelidir.

MapAreaControllerRoute Fonksiyonu:
- MapControllerRoute, default area rotası belirlememizi sağlar.
- MapAreaControllerRoute ise bir area'ya ait/özel rota belirlememizi sağlar.

Area'lar Ara Bağlantı Oluşturma:
- İhtiyaç doğrultusunda area'lar arası bağlantı verilebilmektedir.
- MVC'de kullanılır.
- TagHelpers ve HtmlHelpers ile sağlayabilmekteyiz.
- TagHelper'da asp-area kullanabilmekteyiz.

Area'lar Arası Veri Taşıma İşlemi:
- TempData Kullanabiliriz.



Derinlemesine ViewModel & DTO Yapılanması (AutoMapper Library)

ViewModel: 
- Temelde iki farklı senaryoya karşılık sorumluluk üstlenen ve biz yazılım geliştiricilerin işini kolaylaştıran operasyonel nesnelerdir.
- 1.Senaryo: OOP yapılanmasında bir modelin kullanıcıyla etkileşimi neticesinde kullanılan ve esas datanın memberlarını temsil eden ve süreçte ilgili model yerine veri taşıma/transfer operasyonunu üstlenen bir nesnedir.
- 2.Senaryo: Birden fazla modeli/değeri/veriyi tek bir nesne üzerinde birleştirme görevi gören nesnedir.
- Kullanıcıya sunulan hiçbir veri direkt olarak veritabanındaki entitity türünden olmamalıdır. Bu tarz durumlarda ViewModel kullanılmalıdır.

DTO (Data Transfer Object):
- Herhangi bir davranışı olmayan ve uygulamanın çeşitli yerlerinde yalnızca bir veri tüketimi ve iletimi için kullanılan, veritabanındaki herhangi bir verinin transfer nesnesidir/karşılığıdır/görünümüdür.
- ViewModel ile sıklıkla karıştırılan bir yapılanmadır.

ViewModel ile DTO Karşılaştırması:
ViewModel:
- Kullanıcıya sunulacak verinin view'e uygun/view'in beklediği şekilde tasarlanmış modelidir.
- Veriyi görünüm/sunum/presentation için anlamlı hale getirir.
- İşlevsel fonksiyonlar(metot) barındırabilir.
- İçerisinde bir veya birden fazla DTO temsil edebilir.
- DTO'ya nazaran daha karmaşıktır.

DTO:
- Bir verinin(genellikle veritabanından gelen verinin) transfer modellemesidir. Transfer edilecek olan ilgili verideki sadece ihtiyaç olunan dataları temsil eder.
- Görünüm/sunum/presentation için kullanılabilir lakin bunun dışında uygulamanın herhangi bir katmanında çeşitli veri tüketimi ve transferi içinde kullanılmaktadır.
- Herhangi bir fonksiyonellik barıdırmaz.
- Salt veriyi temsil eder.

Sözleşme/Kontrat Mantığı Nedir?
- Backend'de üretilen bir verinin client'a gönderilmesi için tasarlanan ViewModel o işlemin sözleşmesi/kontratı olmaktadır.
- Haliyle Backend'den gelecek datayı client'ın uygun formatta karşılayabilmesi için kesinlikle o türden bir nesne oluşturması gerekecektir.
- Angular, React gibi frontend kısmında entity modeli oluşturmamız gerekecektir, buna kontrat, sözleşme denir.

ViewModel'lar da Validation Durumları
- Kullanıcıdan alınan veriler iş kuralı gereği kontrol edilirler. Bizler bu kontrollere validation diyoruz.
- Kullanıcılardan gelen veriler kesinlikle veritabanı tablolarının karşılığı olan entity modelleri olmamalıdır! ViewModel olarak alınmalıdır! Ve tüm validation'lar bu ViewModel nesneleri üzerinde gerçekleştirilmelidir.

ViewModel'ı Entity Model'a Nasıl Dönüştürebiliriz?
- Kullanıcıdan gelen dataları ViewModel ile karşıladıktan sonra bu ViewModel'da ki verileri veritabanına kaydetmek isteyebiliriz. Bu durumda, bu verileri Entity Model'a dönüştürmemiz gerkecektir. Bunun için aşağıdaki yöntemlerden herhangi biri kullanılabilir:
- Manuel Dönüştüşrme: Ameleus yöntemi
- Implicit Operator Overload ile Dönüştürme:
- Explicit Operator Overload ile Dönüştürme:
- Reflection ile Dönüştürme
- AutoMapper Kütüphanesi ile Dönüştürme:



appsettings.json Dosyası Nedir? Ne İşe Yarar?
- Ortama göre veya yazılımın parametrelerine göre konfigurasyonlar yapmak isteyebiliriz.
- appsettings.json dosyası, Asp.NET Core uygulamalarında yapılandırma araçlarından birisidir.
- Yapılandırma Nedir?: Yapılandırma, bir uygulamanın herhangi bir ortamda gerçekleştireceği davranışları belirlememizi sağlayan statik değerin tanımlanmasıdır. Yapılandırma genellikle algoritmanın dışında lakin algoritmada kullanılacak olan değerleri belirleme sürecidir.
- Eski Asp.NET uygulamalarında kullanılan web.config yahut Global.asax gibi dosyalar standart framework'ün yapılandırmasında kullanılan ortamlardı.
- Username, password, mail'i gönderecek e-posta ve şifre, smtp port, smptp host, connectionstring...
- Best pratices açısından kodun içerisine username, password, connection string vs. gibi statik tanımlamalar yapılmamalıdır.
- appsettings.json tüm ortamlar için kullanabileceğimiz ortak-genel konfigurasyonları barındırabilirken, appsettings.{Environment}.json dosyaları sadece ilgili ortamda konfigurusyonlara erişmemizi sağlarlar.

Yapılandırma Araçları:
- Appsettings.json | appsettings.{Environment}.json
- Secrets.json (Secret Manager Tools)
- Environment Variables


Options Pattern ile Konfigurasyonları Dependency Injection ile Yapılandırma
- Options Pattern appsettings.json dosyasındaki konfigurasyonları Dependency Injection ile kullanmamızı sağlayan ve yapılandırılmış olan nesnel modellerle ilgili konfigurasyonları temsil etmemizi sağlayan bir tasarım desenidir.



secret.json ile Hassas Verilerin Korunması (Asp.NET Core Secret Manager Tools)
- appsettings'deki hassas veriler connectionstring gibi sunucuya yüklendiğinde açık halde durur. Bu nedenle secret.json gibi farklı dosyalarda tutmamız gerekir.
- Web uygulamalarında development ortamında kullandığımız bazı verilerimizin canlıya deploy edilmesini istemeyebiliriz.
Bu verilerimiz:
- Veritabanı bilgilerini barındıran connection string bilgisi
- Herhangi bir kritik arz eden token değeri,
- Facebook veya Gogole gibi third party authentication işlemleri yapmamızı sağlayan client secret id değerler
vs. olabilir.
- Bu veriler developer ortamında kullanılırken, production ortamında kötü niyetli kişilerin uygulama dosyalarına erişim sağladıkları durumlarda elde edemeyecekleri vaziyette bir şekilde ezilmeleri gerekmektedir.
- İşte bunun için Secret Manager Tool geliştirilmiştir.
- Web uygulamalarında static olan verileri tekrar tekrar yazmak yerine bir merkezde depolayarak kullanmayı tercih ediyoruz.
- Asp.NET Core uygulamalarında bu merkez genellikle "appsettings.json" dosyası olmaktadır.
- Bu dosya içerisine yazılan değerler her ne olursa olsun uygulama publish edildiği taktirde çıktıdan erişilebilir vaziyette olacaktır.
- Dolayısıyla bizler static verilerimizi "appsettings.json" içerisinde tutabiliriz lakin kritik arz eden veriler için burasının pekte güvenli olan bir yer olmadığı aşikardır diyebiliriz.
- secret.json dosyasındaki verileri sadece development aşamasında biz kullanabiliyoruz ancak production ortamına bu secrets.json değerleri publish edilmez. Bu kritik arz eden verileri environment değişkenler olarak göndermemiz gerekir.
- Erişim yapılanmaları yine IConfiguration üzerinden geçerli olacaktır. appsettings.json'a nasıl erişebiliyorsak aynı şekilde secret.json'a da aynı şekilde erişebiliyoruz. Options pattern da birebir geçerlidir.
- Konfigurasyonel yapılanmalardaki yaşam döngüsünde öncelikle Environment'a bakar sonra secret.json'a bakar en son da appsettings.json'a bakar.

Secret Manager Verileri Nerede Depolamaktadır?
- C:\Users\emrep\AppData\Roaming\Microsoft\UserSecrets\



Environment:
- Bir web uygulamasında, uygulamanın bulunduğu aşamalara dayalı, davranışı kontrol etmek ve yönlendirmek isteyebiliriz.
- İşte bunun Environment dediğimiz değişkenler mevcuttur.
- 3 temel ortam bulunur: Development, Staging, Production
- Örneğin production ortamında gerçek veritabanı kullanılır ancak development ve staging ortamlarında localdeki vb. gerçek olmayan veritabanıyla çalışılır.
- Environment Variables: Asp.NET Core uygulamlarının runtime'da ki davranışını belirlememizi sağlayan değişkenlerdir.
- Proje -> Properties -> Debug sekmesinden uygulamaya ait environment'ları görebiliriz. Bir uygulamanın environment'larına buradan erişiyoruz.
- Properties klasörü-> launchSettings.json'den de environmentlara erişebiliriz.
- Uygulama publish edildiğinde otomatik olarak environment Production olarak ayarlanacaktır. Ancak staging ise kendimiz yazmamız gerekir.

ASPNETCORE_ENVIRONMENT Nedir?
- İlgili uygulamanın hangi ortamda ayağa kalkacağını ifade eden bir environment variable'dır.
- IWebHostEnvironment arayüzü ile Runtime Environment Ortamına Erişim. Uygulama hangi environment'taysa o environment'a ait bilgileri elde edebilmekteyiz.

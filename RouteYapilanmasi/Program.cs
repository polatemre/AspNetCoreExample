using RouteYapilanmasi.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Yeni custom oluşturduğumuz route constraint'i ekliyoruz.
builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("custom", typeof(CustomConstraint)));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


// UseRouting() middleware'i tetiklendiği zaman gelen requestteki rotaları ayırmakta ve ilgili rotaya karşılık gelen controller hangisi ise onu ayağa kaldırır ve gerekli action'ı tetikler.

app.UseRouting();

app.UseAuthorization();

// MapControllerRoute middleware'i kendi içerisinde rotaları tutar ve tarif etmemizi sağlar. Kendi custom rotalarımızı da tanımlayabiliriz.
// controller, action gibi değerlerin karşılığını belirtmek zorundayız. (Home, Index gibi)
// Routeları yazarken özelden-genele doğru bir sıralamayla yazmamız gerekir. Çünkü ilk önce özelleri kontrol etsin sonra geneli kontrol etsin
// Geleneksel yaklaşımdır. Buradaki tanımlamalar konvasyoneldir.
// Controller bazlı route yapılanmaları controller üzerinde yapılabilmektedir.

#region Route Constrains
// İstediğim türde değer gelecek kardeşim diyebiliyoruz.
// Karakter boyutunu belirleyebiliyoruz
// Birden fazla kısıtlama ekleyebiliyoruz.

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id:custom:int?}/{x:alpha:maxlength(12)?}/{y:int?}");
#endregion

//app.MapControllerRoute(
//    name: "default3",
//    pattern: "anasayfa", new { controller = "Home", action = "Index" });
//app.MapControllerRoute(
//    name: "default3",
//    pattern: "anasayfa", new { controller = "Home", action = "Index" });
//app.MapControllerRoute(
//    name: "default2",
//    pattern: "{controller=Employee}/{action=Index}");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers(); //controller'da attribute ile route yapılanmasını kullanabilmek için kullanmamız gerekiyor.

app.Run();
 
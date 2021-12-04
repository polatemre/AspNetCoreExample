using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Servislerin eklenecegi kisim baslangic.
// FluentValidation servisini ekledik, validator dosyalarini arama islemini yapacak.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());
// Servislerin eklenme yeri bitis.

var app = builder.Build();


// Http istekleri pipeline baslangic.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();
app.UseRouting();

//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "CustomRoute",
    pattern: "{controller=Home}/{action=Index}/{a}/{b}/{id}");
// Http istekleri pipeline bitis.


app.Run();

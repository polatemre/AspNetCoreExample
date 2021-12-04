using CustomRouteHandler.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseRouting();

app.UseAuthorization();

//controller dışında gelen requesti karşılamak için
//app.Map("example-route", async c =>
//{
//    //https://localhost:5001/example-route endpoint'e gelen herhangi bir istek controller'dan ziyade direkt olarak buradaki fonksiyon tarafından karşılanacaktır.
//});
app.Map("image/{imageName}", new ImageHandler().Handler(app.Environment.WebRootPath));
app.Map("example-route", new ExampleHandler().Handler()); // Buraya gelen request Handler metodu tarafından karşılanacaktır.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

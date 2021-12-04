using InversionOfControl.Services;
using InversionOfControl.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region 1.Kullanım - Tercih Edilmez
// IoC davranışları default olarak singleton'dır. Ancak 3.parametre olarak ya da AddSingleton, AddTransient, AddScoped metotları ile bunu değiştirebiliriz.
// Burada interfaceleri tercih ederiz bu şekilde kullanım tercih edilmez.
//builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
//builder.Services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));
#endregion
#region 2.Kullanım - Interface kullanmadan - Tercih Edilmez
//builder.Services.AddSingleton<ConsoleLog>(); //new T();
//builder.Services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5));

//builder.Services.AddScoped<ConsoleLog>();
//builder.Services.AddScoped<ConsoleLog>(p => new ConsoleLog(5));

//builder.Services.AddTransient<ConsoleLog>();
//builder.Services.AddTransient<ConsoleLog>(p => new ConsoleLog(5));
#endregion
#region 3.Kullanım - Interface ile - Tercih Edilen Kullanım
//builder.Services.AddSingleton<ILog>(p => new ConsoleLog(5));
builder.Services.AddSingleton<ILog, TextLog>();
#endregion


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

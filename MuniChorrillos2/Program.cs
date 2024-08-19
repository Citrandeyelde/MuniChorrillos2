using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MuniChorrillos2.Models;
using MuniChorrillos2.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Añadir servicios de sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Duración de la sesión
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Bdmultas2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnAdrian")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Acceso/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    });
//contenedor de servicios de StripeService
builder.Services.AddSingleton<StripeService>(sp => new StripeService("sk_test_51PpBud2LprDI5sagL4HsosQi94C7fywPrOmdm0NUa1qATxBcHxDGJSbM3afFdWrm7Ag9mbFXOmg96Oaii7zRPgsS00IUVxB1XH"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession(); // Asegúrate de llamar UseSession antes de UseEndpoints()

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

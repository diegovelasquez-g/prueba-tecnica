using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Contracts;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Base de datos
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");
builder.Services.AddDbContext<EquiposDbContext>(options => options.UseSqlServer(connectionString));

//Inyección de dependencias
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();

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

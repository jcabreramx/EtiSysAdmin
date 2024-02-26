
global using EtiSysAdmin.Server.Modelos;
global using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EtiSysAdmin.Server.Utilidades;
using EtiSysAdmin.Server.Servicios.PersonaSV;
using EtiSysAdmin.Server.Repositorios;
using EtiSysAdmin.Server.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DbetiSySAdminContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();

builder.Services.AddScoped<IPersonaServicio, PersonaServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IDepartamentoServicio, DepartamentoServicio>();
builder.Services.AddScoped<IPuestoServicio, PuestoServicio>();
builder.Services.AddScoped<IPerfilServicio, PerfilServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

using EtiSysAdmin.Client;
using EtiSysAdmin.Client.Extensiones;
using EtiSysAdmin.Client.Servicios;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorSpinner;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IPersonaServicio,PersonaServicio>();
builder.Services.AddScoped<ICategoriaServicio,CategoriaServicio>();
builder.Services.AddScoped<IDepartamentoServicio, DepartamentoServicio>();
builder.Services.AddScoped<IPuestoServicio, PuestoServicio>();
builder.Services.AddScoped<IPerfilServicio, PerfilServicio>();
builder.Services.AddScoped<IProductoServicio,ProductoServicio>();
builder.Services.AddScoped<ICarritoServicio,CarritoServicio>();
builder.Services.AddScoped<IVentaServicio,VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SpinnerService>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddScoped<Radzen.TooltipService>();

await builder.Build().RunAsync();

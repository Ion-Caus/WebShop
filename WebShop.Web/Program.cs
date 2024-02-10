using MudBlazor.Services;
using Serilog;
using WebShop.Application.Services;
using WebShop.Application.Services.Impl;
using WebShop.Database;
using WebShop.Web.Components;
using WebShop.Web.Services;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.AddSerilog();

#region Blazor
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();

builder.Services.AddTransient<IUserProfileService, StaticUserProfileService>();
#endregion

#region Database
var connectionString = builder.Configuration.GetConnectionString("Database") 
                       ?? throw new ArgumentException("Database connection string not found.");

MigrationsRunner.Run(connectionString);

builder.Services.AddWebShopDbContext(connectionString);
#endregion

#region Services
builder.Services.AddTransient<IProductService, ProductService>();
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
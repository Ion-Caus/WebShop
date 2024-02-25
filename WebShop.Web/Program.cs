using MudBlazor;
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
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

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
builder.Services.AddTransient<IMasterDataHelper, MasterDataHelper>();
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
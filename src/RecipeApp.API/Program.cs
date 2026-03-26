global using RecipeApp.API.Common;
using RecipeApp.API;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application...");
    var builder = WebApplication.CreateBuilder(args);
    builder.AddServices();
    var app = builder.Build();
    app.Configure();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.CloseAndFlush();
}



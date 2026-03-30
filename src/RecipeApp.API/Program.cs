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
catch (Exception ex) when (ex is not HostAbortedException) // Otherwise it logs an EF.Design error
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.CloseAndFlush();
}



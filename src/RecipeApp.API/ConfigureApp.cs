using Scalar.AspNetCore;
namespace RecipeApp.API;

public static class ConfigureApp
{
    public static void Configure(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.UseHttpsRedirection();
        app.MapEndpoints();
    }
}
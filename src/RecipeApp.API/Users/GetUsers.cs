using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RecipeApp.API.Users;

public class GetUsers : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/{id}", Handle)
        .WithSummary("Get all users");

    public record Request(
        [property: Range(0, int.MaxValue, ErrorMessage = "Id must be greater than 0.")]
        int Id
        );
    
    public record Response(int Id, string Username);

    private static async Task<Results<Ok<Response>, NotFound>> Handle([AsParameters] Request request)
    {
        // EF Core logic

        return TypedResults.Ok(new Response(1, "Test username"));
    }
}
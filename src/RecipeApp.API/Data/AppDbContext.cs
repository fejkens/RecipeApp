using Microsoft.EntityFrameworkCore;
using RecipeApp.API.Data.Entities;

namespace RecipeApp.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureRecipesTable(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureRecipesTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Recipe>();
        
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}

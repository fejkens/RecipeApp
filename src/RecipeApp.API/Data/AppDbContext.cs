using Microsoft.EntityFrameworkCore;
using RecipeApp.API.Data.Entities;

namespace RecipeApp.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUsersTable(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureUsersTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<User>();
        
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}

using Microsoft.EntityFrameworkCore;

namespace Meter.Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Email = "tom@gmail.com", Password = "12345678" },
            new User { Id = 2, Email = "bob@gmail.com", Password = "qwerty" },
            new User { Id = 3, Email = "sam@gmail.com", Password = "asdfgh" }
        );
    }
}
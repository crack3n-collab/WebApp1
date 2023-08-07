using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using FYP2.Model;


namespace FYP2.Areas.Identity.Data;

public class WebApp1IdentityDbContext : IdentityDbContext<WebApp1User>
{
    public WebApp1IdentityDbContext(DbContextOptions<WebApp1IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<Category>()
          .HasIndex(u => u.Id)
          .IsUnique();

        builder.Entity<MenuItem>()
         .HasIndex(u => u.Id)
         .IsUnique();

    }

    public DbSet<FYP2.Model.Category> Category { get; set; } = default!;

    public DbSet<FYP2.Model.MenuItem> MenuItem { get; set; } = default!;
}

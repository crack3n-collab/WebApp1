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

        builder.Entity<Orders>()
          .HasMany(p => p.Items)
          .WithOne(c => c.Order)
          .HasForeignKey(c => c.OrderID);
        this.SeedRoles(builder);
        this.SeedUsers(builder);
        this.SeedUserRoles(builder);
    }
    private void SeedUsers(ModelBuilder builder)
    {
        WebApp1User user = new WebApp1User()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Admin",
            Email = "admin@gmail.com",
            LockoutEnabled = false,
            PhoneNumber = "1234567890"
        };

        PasswordHasher<WebApp1User> passwordHasher = new PasswordHasher<WebApp1User>();
        passwordHasher.HashPassword(user, "Admin*123");

        builder.Entity<WebApp1User>().HasData(user);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
    }
    public DbSet<FYP2.Model.Category> Category { get; set; } = default!;

    public DbSet<FYP2.Model.MenuItem> MenuItem { get; set; } = default!;

    public DbSet<FYP2.Model.Orders> Orders { get; set; } = default!;
    public DbSet<FYP2.Model.OrderItem> OrderItems { get; set; } = default!;

}

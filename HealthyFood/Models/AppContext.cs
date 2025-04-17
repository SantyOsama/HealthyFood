using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthyFood.Models;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Review> Reviews { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Order>()
    //        .Property(o => o.TotalPrice)
    //        .HasColumnType("decimal(18, 2)");

    //    modelBuilder.Entity<OrderDetails>()
    //        .Property(od => od.Subtotal)
    //        .HasColumnType("decimal(18, 2)");

    //    modelBuilder.Entity<Product>()
    //        .Property(p => p.Price)
    //        .HasColumnType("decimal(18, 2)");

    //    base.OnModelCreating(modelBuilder);
    //}

}

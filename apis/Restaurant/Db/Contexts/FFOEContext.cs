using System.Security.AccessControl;
using Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Db.Contexts;

public class FFOEContext : DbContext
{
    public FFOEContext(DbContextOptions<FFOEContext> options) : base(options) {}

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ComboDetails> ComboDetails { get; set; }
    public DbSet<ProductDiscount> ProductDiscounts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<CouponType> CouponTypes { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(p => p.Email)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(p => p.Phone)
            .IsUnique();


        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductDiscount)
            .WithOne()
            .HasForeignKey(pd => pd.ProductId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Product>()
            .HasMany(p => p.ComboDetails)
            .WithOne()
            .HasForeignKey(cd => cd.ComboId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<ComboDetails>()
            .HasOne(cd => cd.Product)
            .WithMany()
            .HasForeignKey(cd => cd.ProductId)
            .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne()
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<OrderDetails>()
            .HasOne(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductId)
            .OnDelete(DeleteBehavior.SetNull);


        modelBuilder.Entity<CouponType>()
            .HasMany(cpt => cpt.Coupons)
            .WithOne()
            .HasForeignKey(cp => cp.CouponTypeId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Customer>()
            .HasMany(ctm => ctm.Coupons)
            .WithOne()
            .HasForeignKey(cp => cp.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        
        modelBuilder.Entity<Customer>()
            .HasMany(ctm => ctm.Orders)
            .WithOne()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

    }

}
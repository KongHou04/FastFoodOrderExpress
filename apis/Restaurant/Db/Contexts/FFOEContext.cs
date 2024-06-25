using Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Db.Contexts;

public class FFOEContext : DbContext
{
    public FFOEContext(DbContextOptions<FFOEContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set unique fiekld
        modelBuilder.Entity<Category>()
            .HasIndex(p => p.Name)
            .IsUnique();

        // Set unique fiekld
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
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
using Db.Contexts;
using Db.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Interfaces;

namespace Repositories.Implements;

public class CouponRES(FFOEContext context) : BaseRES(context), ICouponRES
{
    public bool Add(int couponTypeId, int number = 20)
    {
        if (number <= 0)
            throw new Exception("Invalid number");
        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            for (int i = 0; i < number; i++)
            {
                var c = new Coupon() { IsUsed = false, CustomerId = null, CouponTypeId =couponTypeId };
                context.Coupons.Add(c);
            }
            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), "ID cannot be empty.");

        try
        {
            var coupon = context.Set<Coupon>().Find(id);
            if (coupon == null)
                return false;

            context.Set<Coupon>().Remove(coupon);
            context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting Coupon.", ex);
        }
    }

    public Coupon? GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), "Coupon ID cannot be empty.");

        try
        {
            return context.Set<Coupon>().Find(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving Category by ID.", ex);
        }
    }

    public IEnumerable<Coupon> GetByCustomer(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentNullException(nameof(customerId), "Customer ID cannot be empty.");

        try
        {
            return context.Set<Coupon>().Where(cp => cp.CustomerId == customerId);
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving Coupons by customer.", ex);
        }
    }

    public Coupon? Update(Coupon obj, Guid id)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "Coupon object cannot be null.");

        if (id == Guid.Empty)
            throw new ArgumentException("Coupon ID cannot be empty.", nameof(id));

        try
        {
            var existingCoupon = context.Set<Coupon>().FirstOrDefault(c => c.Id == id);
            if (existingCoupon is null)
                return null;

            existingCoupon.IsUsed = obj.IsUsed;
            existingCoupon.CustomerId = obj.CustomerId;

            context.SaveChanges();
            return existingCoupon;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating Coupon with ID {id}.", ex);
        }
    }
}
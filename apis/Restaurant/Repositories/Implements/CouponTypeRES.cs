using Db.Contexts;
using Db.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Interfaces;

namespace Repositories.Implements;

public class CouponTypeRES(FFOEContext context) : BaseRES(context), ICouponTypeRES
{
    public CouponType Add(CouponType obj)
    {
        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            var entry = context.CouponTypes.Add(obj);
            var addedObj = entry.Entity;
            context.SaveChanges();
            transaction.Commit();
            return obj;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var couponType = context.Set<CouponType>().Find(id);
            if (couponType == null)
                return false;

            context.Set<CouponType>().Remove(couponType);
            context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting CouponType.", ex);
        }
    }

    public IEnumerable<CouponType> Get()
    {
        try
        {
            return context.CouponTypes;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving CouponType list.", ex);
        }
    }

    public CouponType? GetById(int id)
    {
        try
        {
            return context.Set<CouponType>().Find(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving CouponType by ID.", ex);
        }
    }

    public CouponType? Update(CouponType obj, int id)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "CouponType object cannot be null.");

        try
        {
            var existingCouponType = context.Set<CouponType>().FirstOrDefault(c => c.Id == id);
            if (existingCouponType is null)
                return null;

            existingCouponType.PercentValue = obj.PercentValue;
            existingCouponType.HardValue = obj.HardValue;
            existingCouponType.StartTime = obj.StartTime;
            existingCouponType.EndTime = obj.EndTime;

            context.SaveChanges();
            return existingCouponType;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating CouponType with ID {id}.", ex);
        }
    }
}
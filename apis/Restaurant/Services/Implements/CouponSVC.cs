using Db.Models;
using Models;
using Services.Interfaces;

namespace Services.Implements;

public class CouponSVC : ICouponSVC
{
    public Response Add(int couponTypeId, int quantity = 1)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Response GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response GetByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Response GetValidByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Response Update(Coupon obj, int id)
    {
        throw new NotImplementedException();
    }

    public Response UpdateUser(int couponType, Guid userId, int quantity = 1)
    {
        throw new NotImplementedException();
    }
}
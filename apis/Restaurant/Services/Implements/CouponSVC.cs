using Db.Models;
using Models;
using Services.Interfaces;

namespace Services.Implements;

public class CouponSVC : ICouponSVC
{
    public Response Add(int couponTypeId, int quantity = 20)
    {
        throw new NotImplementedException();
    }

    public Response Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response GetByCustomer(Guid customerId)
    {
        throw new NotImplementedException();
    }

    public Response GetValidByCustomer(Guid customerId)
    {
        throw new NotImplementedException();
    }

    public Response Update(Coupon obj, Guid id)
    {
        throw new NotImplementedException();
    }

    public Response UpdateUser(int couponType, Guid userId, int quantity = 1)
    {
        throw new NotImplementedException();
    }
}
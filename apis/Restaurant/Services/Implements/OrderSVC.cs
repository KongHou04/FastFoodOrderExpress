using Db.Models;
using Models;
using Services.Interfaces;

namespace Services.Implements;

public class OrderSVC : IOrderSVC
{
    public Response Add(Order obj)
    {
        throw new NotImplementedException();
    }

    public Response CancelOrder(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response Get()
    {
        throw new NotImplementedException();
    }

    public Response GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response GetByUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Response Update(Order obj, Guid id)
    {
        throw new NotImplementedException();
    }

    public Response UpdateDeliveryStatus(int deliveryStatus, Guid id)
    {
        throw new NotImplementedException();
    }

    public Response UpdateDiscount(Guid couponCode, Guid id)
    {
        throw new NotImplementedException();
    }

    public Response UpdateOrderDetails(Order obj, Guid id)
    {
        throw new NotImplementedException();
    }

    public Response UpdatePaymentStatus(int paymentStatus, Guid id)
    {
        throw new NotImplementedException();
    }


    // Checks if order value is valid or not.
    // Checks
    //      Is each product unitprice valid
    //      Total numbers (total = subtotal - discount)
    //      OrderTime mus be null
    // For each error, add into a List<string>
    // Return List<string> of errors
    public List<string> ValidateOrder(Order obj, bool isIdCheck)
    {
        throw new NotImplementedException();
    }
}
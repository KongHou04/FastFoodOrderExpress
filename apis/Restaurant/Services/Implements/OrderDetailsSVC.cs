using Db.Models;
using Models;
using Services.Interfaces;

namespace Services.Implements;

public class OrderDetailsSVC : IOrderDetailsSVC
{
    public Response Add(OrderDetails obj)
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

    public Response Update(OrderDetails obj, Guid id)
    {
        throw new NotImplementedException();
    }

    public List<string> ValidateOrder(OrderDetails obj, bool isIdCheck)
    {
        throw new NotImplementedException();
    }
}
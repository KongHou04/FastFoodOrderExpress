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

    public Response Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Response GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Response GetByOrder(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Response Update(OrderDetails obj, int id)
    {
        throw new NotImplementedException();
    }

    public List<string> ValidateOrder(OrderDetails obj, bool isIdCheck)
    {
        throw new NotImplementedException();
    }
}
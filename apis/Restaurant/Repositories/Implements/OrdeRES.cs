using Db.Models;
using Repositories.Interfaces;

namespace Repositories.Implements;

public class OrderRES : IOrderRES
{
    public Order? Add(Order obj)
    {
        throw new NotImplementedException();
    }

    public Order? Cancel(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool? Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Order> Get(int numberOfOrder)
    {
        throw new NotImplementedException();
    }

    public Order? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Order? GetByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Order? Update(Order obj, Guid id)
    {
        throw new NotImplementedException();
    }

    public Order? UpdateDeliveryStatus(int status, Guid id)
    {
        throw new NotImplementedException();
    }

    public Order? UpdatePaymentStatus(int status, Guid id)
    {
        throw new NotImplementedException();
    }
}
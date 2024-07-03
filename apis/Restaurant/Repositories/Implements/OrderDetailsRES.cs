using Db.Models;
using Repositories.Interfaces;

namespace Repositories.Implements;

public class OrderDetailsRES : IOrderDetailsRES
{
    public OrderDetails? Add(OrderDetails obj)
    {
        throw new NotImplementedException();
    }

    public bool? Delete(int id)
    {
        throw new NotImplementedException();
    }

    public OrderDetails? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderDetails> GetByOrder(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public OrderDetails? Update(OrderDetails obj, int id)
    {
        throw new NotImplementedException();
    }
}
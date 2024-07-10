using Db.Models;
using Models;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements;

public class OrderDetailsSVC(IOrderDetailsRES orderDetailRES) : IOrderDetailsSVC
{
    public Response Add(OrderDetails obj)
    {
        try
        {
            var addedObj = orderDetailRES.Add(obj);
            return new Response(true, "Added new order detail successfully.", addedObj);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while adding the new order detail.", null, new List<string> { ex.Message });
        }
    }

    public Response Delete(int id)
    {
        try
        {
            var isDeleted = orderDetailRES.Delete(id);
            if (isDeleted)
                return new Response(true, "Deleted order detail successfully.", isDeleted);
            else
                return new Response(false, "No order detail with the given ID found.");
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while deleting the order detail with the given ID.", null, new List<string> { ex.Message });
        }
    }

    public Response GetById(int id)
    {
        try
        {
            var od = orderDetailRES.GetById(id);
            return new Response(true, "Get the order detail by ID successfully.", od);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while get the order detail.", null, new List<string> { ex.Message });
        }
    }

    public Response GetByOrder(Guid orderId)
    {
        try
        {
            var od = orderDetailRES.GetByOrder(orderId);
            return new Response(true, "Get the order detail by OrderID successfully.", od);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while getting the order detail.", null, new List<string> { ex.Message });
        }
    }

    public Response Update(OrderDetails obj, int id)
    {
        try
        {
            var od = orderDetailRES.Update(obj,id);
            return new Response(true, "Update the order detail successfully.", od);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while updatung the order detail.", null, new List<string> { ex.Message });
        }
    }

    public List<string> ValidateOrder(OrderDetails obj, bool isIdCheck)
    {
        throw new NotImplementedException();
    }
}
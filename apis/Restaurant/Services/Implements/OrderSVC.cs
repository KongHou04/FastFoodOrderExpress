using Db.Models;
using Models;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements;

public class OrderSVC(IOrderRES orderRES) : IOrderSVC
{
    public Response Add(Order obj)
    {
        try
        {
            var result = orderRES.Add(obj);
            return new Response(true, "Add new order successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }


    // chưa biết lưu order theo sesion hay db
    public Response CancelOrder(Guid id)
    {
        try
        {
            var result = orderRES.Cancel(id);
            return new Response(true, "Delete the category successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response Delete(Guid id)
    {
        try
        {
            var result = orderRES.Delete(id);
            return new Response(true, "Delete the category successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response Get()
    {
        try
        {
            var data = orderRES.Get(int.MaxValue);
            return new Response(true, "Get all order successfully", data);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response GetById(Guid id)
    {
        try
        {
            var result = orderRES.GetById(id);
            if (result is null)
                return new Response(true, "There are no order matching the id");

            return new Response(true, "The order has been found", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response GetByUser(Guid id)
    {
        try
        {
            var result = orderRES.GetByCustomer(id);
            if (result is null)
                return new Response(true, "There are no Customer matching the id");

            return new Response(true, "The Customer has been found", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response Update(Order obj, Guid id)
    {
        try
        {
            var result = orderRES.Update(obj, id);
            return new Response(true, "Update the category successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response UpdateDeliveryStatus(int deliveryStatus, Guid id)
    {
        try
        {
            var result = orderRES.UpdateDeliveryStatus(deliveryStatus, id);
            return new Response(true, "Update the category successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response UpdateDiscount(Guid couponCode, Guid id)
    {
        try
        {
            var result = orderRES.UpdateDiscount(couponCode, id);
            return new Response(true, "Update the discount successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response UpdateOrderDetails(Order obj, Guid id)
    {
        try
        {
            var result = orderRES.UpdateOrderDetails(obj, id);
            return new Response(true, "Update the order details successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
    }

    public Response UpdatePaymentStatus(int paymentStatus, Guid id)
    {
        try
        {
            var result = orderRES.UpdatePaymentStatus(paymentStatus, id);
            return new Response(true, "Update the payment status successfully", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Errors occur from server", null, new List<string> { ex.Message });
        }
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
        var errors = new List<string>();

        if (obj == null)
        {
            errors.Add("Order cannot be null");
            return errors;
        }

        if (isIdCheck && obj.Id == Guid.Empty)
        {
            errors.Add("Order Id is invalid");
        }

        if (obj.OrderDetails == null || !obj.OrderDetails.Any())
        {
            errors.Add("Order must have at least one order detail");
        }

        foreach (var detail in obj.OrderDetails)
        {
            if (detail.UnitPrice <= 0)
            {
                errors.Add($"Product {detail.ProductId} has an invalid unit price");
            }
        }

        if (obj.Total != obj.SubTotal - obj.Discount)
        {
            errors.Add("Total amount does not match subtotal minus discount");
        }

        if (obj.OrderTime == null)
        {
            errors.Add("Order time must be specified");
        }

        return errors;
    }
}
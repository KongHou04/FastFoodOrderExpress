using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Implements;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/orderdetails")]
public class OrderDetailsController(IOrderDetailsSVC orderDetailsSVC) : ControllerBase
{

    [HttpGet("order/{id}")]
    public Response GetByProduct(Guid orderId)
    {
        return orderDetailsSVC.GetByOrder(orderId);
    }

    [HttpGet("{id}")]
    public Response GetById(int id)
    {
        return orderDetailsSVC.GetById(id);
    }

    [HttpPost()]
    public Response Add([FromBody] OrderDetails obj)
    {
        return orderDetailsSVC.Add(obj);
    }

    [HttpPut("{id}")]
    public Response Update([FromBody] OrderDetails obj, [FromRoute] int id)
    {
        return orderDetailsSVC.Update(obj, id);
    }

    [HttpDelete("{id}")]
    public Response Delete([FromRoute] int id)
    {
        return orderDetailsSVC.Delete(id);
    }
}
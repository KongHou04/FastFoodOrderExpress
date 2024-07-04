using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IOrderSVC orderSVC) : ControllerBase
{
    [HttpGet("{id}")]
    public Response GetById(Guid id)
    {
        return orderSVC.GetById(id);
    }

    [HttpGet("user")]
    public Response GetbyUser()
    {
        // Use authenticate to get user information
        // After that, use the user id to get all orders of the user
        // Follow the code below
        //var userId = user id form context request
        //if (userId is not null)
        //return orderSVC.GetByUser(userId);
        throw new NotImplementedException();
    }

    [HttpPost()]
    public Response Add(Order obj)
    {
        return orderSVC.Add(obj);
    }

    // This endpoins will not update item of the order sent
    // If you want to update order item details, use orderdetailsController instead
    [HttpPut("{id}")]
    public Response Update(Order obj, Guid id)
    {
        return orderSVC.Add(obj);
    }

    [HttpDelete()]
    public Response Delete(Guid id)
    {
        return orderSVC.Delete(id);
    }

}
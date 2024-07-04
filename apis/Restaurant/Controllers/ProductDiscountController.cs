using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Implements;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/productdiscounts")]
public class ProductDiscountController(IProductDiscountSVC productDiscountSVC) : ControllerBase
{
    [HttpGet("{id}")]
    public Response GetById(int id)
    {
        return productDiscountSVC.GetById(id);
    }

    [HttpGet("product/{id}")]
    public Response GetByProduct(Guid id)
    {
        return productDiscountSVC.GetByProduct(id);
    }


    [HttpPost()]
    public Response Add([FromBody] ProductDiscount obj)
    {
        return productDiscountSVC.Add(obj);
    }

    [HttpPut("{id}")]
    public Response Update([FromBody] ProductDiscount obj, [FromRoute] int id)
    {
        return productDiscountSVC.Update(obj, id);
    }

    [HttpDelete("{id}")]
    public Response Delete([FromRoute] int id)
    {
        return productDiscountSVC.Delete(id);
    }
}


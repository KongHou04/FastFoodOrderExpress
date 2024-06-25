using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace restaurant.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController(ICategorySVC categorySVC) : ControllerBase
{
    [HttpPost("{name}")]
    public string HelloWorld(string name)
    {
        return "Hello world. " + "I am " + name;
    }

    [HttpGet()]
    public IEnumerable<Category> Get()
    {
        return categorySVC.Get();
    }

    [HttpGet("{id}")]
    public Category? Get(Guid id)
    {
        return categorySVC.GetById(id);
    }


    [HttpPost]
    public string Post([FromBody]Category category)
    {
        return categorySVC.Add(category);
    }

    [HttpPut("{id}")]
    public string Post([FromBody] Category category, Guid id)
    {
        return categorySVC.Update(category, id);
    }

    [HttpDelete()]
    public string Delete(Guid id)
    {
        return categorySVC.Delete(id);
    }
}

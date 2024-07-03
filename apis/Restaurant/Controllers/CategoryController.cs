using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(ICategorySVC categorySVC) : ControllerBase
{
    [HttpPost("{name}")]
    public string HelloWorld(string name)
    {
        return "Hello world. " + "I am " + name;
    }

    /// <summary>
    ///     Get all categories
    /// </summary>
    /// <returns></returns>
    [HttpGet("getall")]
    public Response Get()
    {
        return categorySVC.Get();
    }

    /// <summary>
    ///     Get an category by searching by id
    /// </summary>
    /// <param name="id">Category id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Response Get(Guid id)
    {
        return categorySVC.GetById(id);
    }

    /// <summary>
    ///     Add a new category
    /// </summary>
    /// <param name="category">New category</param>
    /// <returns></returns>
    [HttpPost]
    public Response Post([FromBody]Category category)
    {
        return categorySVC.Add(category);
    }

    /// <summary>
    ///     Update an existing category
    /// </summary>
    /// <param name="category">New category infor</param>
    /// <param name="id">Update id</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Response Post([FromBody] Category category, Guid id)
    {
        return categorySVC.Update(category, id);
    }

    /// <summary>
    ///     Delete an existing category
    /// </summary>
    /// <param name="id">delete id</param>
    /// <returns></returns>
    [HttpDelete()]
    public Response Delete(Guid id)
    {
        return categorySVC.Delete(id);
    }
}

using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
///     Category service interface
/// </summary>
public interface ICategorySVC
{
    // These function is in testing
    // Do not change it

    public IEnumerable<Category> Get();

    // public Category? GetById(Guid id);

    public string Add(Category obj);

    public string Update(Category obj, Guid id);

    public string Delete(Guid id);

    public Response GetById(Guid id);
}
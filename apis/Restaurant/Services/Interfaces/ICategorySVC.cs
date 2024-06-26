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

    public Response Get();

    // public Category? GetById(Guid id);

    public Response Add(Category obj);

    public Response Update(Category obj, Guid id);

    public Response Delete(Guid id);

    public Response GetById(Guid id);
}
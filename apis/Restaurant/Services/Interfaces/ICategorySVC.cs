using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for category services providing CRUD operations for categories.
/// </summary>
public interface ICategorySVC
{
    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A Response object containing the list of all categories and status information about the retrieval process.</returns>
    public Response Get();



    /// <summary>
    /// Retrieves a specific category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>A Response object containing the category details and status information about the retrieval process.</returns>
    public Response GetById(Guid id);



    /// <summary>
    /// Adds a new category.
    /// </summary>
    /// <param name="obj">The new category to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    public Response Add(Category obj);



    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="obj">The updated details of the category.</param>
    /// <param name="id">The unique identifier of the category to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response Update(Category obj, Guid id);



    /// <summary>
    /// Deletes a specific category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    public Response Delete(Guid id);
}

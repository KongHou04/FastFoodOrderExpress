using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for product services providing CRUD operations and Personal operations for products.
/// </summary>
public interface IProductSVC
{
    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A Response object containing the list of all products  and status information about the retrieval process.</returns>
    Response Get();



    /// <summary>
    /// Retrieves a specific product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve.</param>
    /// <returns>A Response object containing the details of the specified product and status information about the retrieval process.</returns>
    Response GetById(Guid id);



    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="obj">The new product to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    Response Add(Product obj);



    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="obj">The updated details of the product.</param>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    Response Update(Product obj, Guid id);



    /// <summary>
    /// Deletes a specific product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    Response Delete(Guid id);
}
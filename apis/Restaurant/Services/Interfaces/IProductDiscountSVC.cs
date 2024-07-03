using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for product discount services providing CRUD operations for product discounts.
/// </summary>
public interface IProductDiscountSVC
{
    /// <summary>
    /// Retrieves all discounts for a specific product by its unique identifier.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <returns>A Response object containing the list of discounts for the product and status information about the retrieval process.</returns>
    Response GetByProduct(Guid productId);



    /// <summary>
    /// Adds a new product discount.
    /// </summary>
    /// <param name="obj">The new product discount to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    Response Add(ProductDiscount obj);



    /// <summary>
    /// Updates an existing product discount.
    /// </summary>
    /// <param name="obj">The updated details of the product discount.</param>
    /// <param name="id">The unique identifier of the product discount to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    Response Update(ProductDiscount obj, int id);



    /// <summary>
    /// Deletes a specific product discount by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product discount to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    Response Delete(int id);
}

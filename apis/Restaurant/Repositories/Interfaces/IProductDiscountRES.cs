using Db.Models;

namespace Repositories.Interfaces;

/// <summary>
/// Interface for ProductDiscount repository providing CRUD operations for product discounts.
/// </summary>
public interface IProductDiscountRES
{
    /// <summary>
    /// Retrieves all product discounts for a specific product from the database.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <returns>An <see cref="IEnumerable{ProductDiscount}"/> containing all discounts for the specified product.</returns>
    public IEnumerable<ProductDiscount> GetByProduct(Guid productId);

    /// <summary>
    /// Retrieves a product discount by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product discount to retrieve.</param>
    /// <returns>The product discount if found; otherwise, null.</returns>
    public ProductDiscount? GetById(int id);

    /// <summary>
    /// Adds a new product discount to the database.
    /// </summary>
    /// <param name="obj">The product discount to add to the database.</param>
    /// <returns>The added product discount, or <c>null</c> if the operation failed.</returns>
    public ProductDiscount? Add(ProductDiscount obj);

    /// <summary>
    /// Updates an existing product discount in the database.
    /// </summary>
    /// <param name="obj">The updated product discount to save in the database.</param>
    /// <param name="id">The unique identifier of the product discount to be updated.</param>
    /// <returns>The updated product discount if the update was successful, or <c>null</c> if no matching product discount was found or the operation failed.</returns>
    public ProductDiscount? Update(ProductDiscount obj, int id);

    /// <summary>
    /// Deletes an existing product discount from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the product discount to be deleted.</param>
    /// <returns>
    /// <c>true</c> if the product discount was successfully deleted; 
    /// <c>false</c> if no matching product discount was found; 
    /// <c>null</c> if the deletion failed due to an error.
    /// </returns>
    public bool? Delete(int id);
}

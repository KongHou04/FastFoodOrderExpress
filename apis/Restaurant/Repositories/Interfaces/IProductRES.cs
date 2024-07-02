using Db.Models;

namespace Repositories.Interfaces;

/// <summary>
/// Interface for Product repository providing CRUD operations for products.
/// </summary>
public interface IProductRES
{
    /// <summary>
    /// Retrieves all products from the database.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{Product}"/> containing all products.</returns>
    /// <exception cref="Exception">Thrown when an error occurs while retrieving products.</exception>
    public IEnumerable<Product> Get();

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve.</param>
    /// <returns>The product if found; otherwise, null.</returns>
    /// <exception cref="Exception">Thrown when an error occurs while retrieving the product.</exception>
    public Product GetById(Guid id);

    /// <summary>
    /// Adds a new product to the database.
    /// </summary>
    /// <param name="obj">The product to add to the database.</param>
    /// <returns>The added product.</returns>
    /// <exception cref="Exception">Thrown when an error occurs while adding the product.</exception>
    public Product Add(Product obj);

    /// <summary>
    /// Updates an existing product in the database.
    /// </summary>
    /// <param name="obj">The updated product to save in the database.</param>
    /// <param name="id">The unique identifier of the product to be updated.</param>
    /// <returns>The updated product if the update was successful, or null if no matching product was found.</returns>
    /// <exception cref="Exception">Thrown when an error occurs while updating the product.</exception>
    public Product? Update(Product obj, Guid id);

    /// <summary>
    /// Deletes an existing product from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the product to be deleted.</param>
    /// <returns>
    /// <c>true</c> if the product was successfully deleted; 
    /// <c>false</c> if no matching product was found.
    /// </returns>
    /// <exception cref="Exception">Thrown when an error occurs while deleting the product.</exception>
    public bool Delete(Guid id);
}

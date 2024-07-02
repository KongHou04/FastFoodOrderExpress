using Db.Contexts;
using Db.Models;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repositories.Implements;

public class ProductRES(FFOEContext context) : BaseRES(context), IProductRES
{
    /// <summary>
    ///     Adds a new Product object to the database within a transaction.
    ///     If the operation is successful, the transaction is committed.
    ///     If an error occurs, the transaction is rolled back.
    /// </summary>
    /// <param name="obj">The Product object to be added to the database.</param>
    /// <returns>
    ///     The added Product object if the operation is successful.
    /// </returns>
    /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
    public Product Add(Product obj)
    {
        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            // Add the new product
            var entry = context.Products.Add(obj);
            var addedObj = entry.Entity;
            context.SaveChanges();

            // Commit the transaction
            transaction.Commit();
            return addedObj;
        }
        catch (Exception)
        {
            // Rollback the transaction if an error occurs
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>
    ///     Deletes a Product object from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the Product object to delete.</param>
    /// <returns>
    ///     True if the Product object is successfully deleted, false if object does not exist;
    /// </returns>
    /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
    public bool Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), "ID cannot be empty.");

        try
        {
            // Retrieve the Product object by ID
            var product = context.Set<Product>().Find(id);

            if (product == null)
                return false;

            // Remove the product from DbSet and save changes
            context.Set<Product>().Remove(product);
            context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error deleting Product.", ex);
        }
    }

    /// <summary>
    ///     Retrieves all Product objects from the database.
    /// </summary>
    /// <returns>
    ///     An enumerable collection of Product objects.
    /// </returns>
    /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
    public IEnumerable<Product> Get()
    {
        try
        {
            // Retrieve all Product objects from DbSet
            var products = context.Products;
            return products;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error retrieving Product list.", ex);
        }
    }

    /// <summary>
    ///     Retrieves a Product object from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the Product object to retrieve.</param>
    /// <returns>
    ///     The Product object with the specified ID if found.
    /// </returns>
    /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
    public Product GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), "Product ID cannot be empty.");

        try
        {
            // Retrieve the Product object by ID
            var product = context.Set<Product>().Find(id);

            return product ?? throw new Exception($"Product with ID {id} not found.");
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error retrieving Product by ID.", ex);
        }
    }

    /// <summary>
    ///     Updates an existing Product object in the database based on the provided object and ID.
    /// </summary>
    /// <param name="obj">The Product object with updated information.</param>
    /// <param name="id">The ID of the Product object to update.</param>
    /// <returns>
    ///     The updated Product object if successful, null if product with given id not found.
    /// </returns>
    /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
    public Product? Update(Product obj, Guid id)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Product object cannot be null.");
        }

        if (id == Guid.Empty)
        {
            throw new ArgumentException("Product ID cannot be empty.", nameof(id));
        }

        try
        {
            var existingProduct = context.Set<Product>().FirstOrDefault(p => p.Id == id);

            if (existingProduct is null)
                return null; // Product with given ID not found

            // Updates the existing product
            existingProduct.Name = obj.Name;
            existingProduct.Description = obj.Description;
            existingProduct.UnitPrice = obj.UnitPrice;
            existingProduct.Image = obj.Image;
            existingProduct.CategoryId = obj.CategoryId;

            context.SaveChanges();
            return existingProduct;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception($"Error updating Product with ID {id}.", ex);
        }
    }
}

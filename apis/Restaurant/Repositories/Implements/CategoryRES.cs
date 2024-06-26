using Db.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Db.Contexts;

namespace Repositories.Implements;

public class CategoryRES(FFOEContext context) : BaseRES(context), ICategoryRES
{
    /// <summary>
    ///     Adds a new Category object to the database within a transaction.
    ///     If the operation is successful, the transaction is committed.
    ///     If an error occurs, the transaction is rolled back.
    /// </summary>
    /// <param name="obj">The Category object to be added to the database.</param>
    /// <returns>
    ///     The added Category object if the operation is successful.
    ///     Throws an exception if an error occurs during the operation.
    /// </returns>
    public Category? Add(Category obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            // Add the new category
            var entry = context.Categories.Add(obj);
            var addedObj = entry.Entity;
            context.SaveChanges();

            // Commit the transaction
            transaction.Commit();
            return obj;
        }
        catch (Exception)
        {
            // Rollback the transaction if an error occurs
            transaction.Rollback();
            throw;
        }

    }



    /// <summary>
    ///     Deletes a Category object from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the Category object to delete.</param>
    /// <returns>
    ///     True if the Category object is successfully deleted; otherwise, false.
    /// </returns>
    public bool? Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Category ID cannot be empty.");
        }

        try
        {
            // Retrieve the Category object by ID
            var category = context.Set<Category>().Find(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID '{id}' not found.");
            }

            // Remove the category from DbSet and save changes
            context.Set<Category>().Remove(category);
            context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error deleting Category.", ex);
        }
    }



    /// <summary>
    ///     Retrieves all Category objects from the database.
    /// </summary>
    /// <returns>
    ///     An enumerable collection of Category objects.
    /// </returns>
    public IEnumerable<Category> Get()
    {
        try
        {
            // Retrieve all Category objects from DbSet
            var categories = context.Categories;
            return categories;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error retrieving Category list.", ex);
        }
    }



    /// <summary>
    ///     Retrieves a Category object from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the Category object to retrieve.</param>
    /// <returns>
    ///     The Category object with the specified ID if found; otherwise, null.
    /// </returns>
    public Category? GetById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Category ID cannot be empty.");
        }

        try
        {
            // Retrieve the Category object by ID
            var category = context.Set<Category>().Find(id);

            return category;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception("Error retrieving Category by ID.", ex);
        }
    }



    /// <summary>
    ///     Updates an existing Category object in the database based on the provided object and ID.
    /// </summary>
    /// <param name="obj">The Category object with updated information.</param>
    /// <param name="id">The ID of the Category object to update.</param>
    /// <returns>
    ///     The updated Category object if successful, otherwise null.
    /// </returns>
    public Category? Update(Category obj, Guid id)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Category object cannot be null.");
        }

        if (id == Guid.Empty)
        {
            throw new ArgumentException("Category ID cannot be empty.", nameof(id));
        }

        try
        {
            var existingCategory = context.Set<Category>().FirstOrDefault(c => c.Id == id);

            if (existingCategory is null)
                return null; // Category with given ID not found

            // Updates the exsting category
            existingCategory.Name = obj.Name;
            existingCategory.Description = obj.Description;

            context.SaveChanges();
            return existingCategory;
        }
        catch (Exception ex)
        {
            // Handle any exception and log if necessary
            throw new Exception($"Error updating Category with ID {id}.", ex);
        }
    }

}
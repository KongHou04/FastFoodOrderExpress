using Db.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Db.Contexts;

namespace Repositories.Implements;

/// <summary>
/// Repository for handling Category-related operations in the database.
/// </summary>
public class CategoryRES(FFOEContext context) : BaseRES(context), ICategoryRES
{
    /// <summary>
    /// Adds a new Category object to the database within a transaction.
    /// If the operation is successful, the transaction is committed.
    /// If an error occurs, the transaction is rolled back.
    /// </summary>
    /// <param name="obj">The Category object to be added to the database.</param>
    /// <returns>The added Category object if the operation is successful.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during the operation.</exception>
    public Category Add(Category obj)
    {
        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            var entry = context.Categories.Add(obj);
            var addedObj = entry.Entity;
            context.SaveChanges();
            transaction.Commit();
            return obj;
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>
    /// Deletes a Category object from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the Category object to delete.</param>
    /// <returns>True if the Category object is successfully deleted, false if category with given id not found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during the operation.</exception>
    public bool Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), "ID cannot be empty.");

        try
        {
            var category = context.Set<Category>().Find(id);
            if (category == null)
                return false;

            context.Set<Category>().Remove(category);
            context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting Category.", ex);
        }
    }

    /// <summary>
    /// Retrieves all Category objects from the database.
    /// </summary>
    /// <returns>An enumerable collection of Category objects.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during the operation.</exception>
    public IEnumerable<Category> Get()
    {
        try
        {
            return context.Categories;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving Category list.", ex);
        }
    }

    /// <summary>
    /// Retrieves a Category object from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the Category object to retrieve.</param>
    /// <returns>The Category object with the specified ID if found, null if not.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during the operation.</exception>
    public Category? GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id), "Category ID cannot be empty.");

        try
        {
            return context.Set<Category>().Find(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving Category by ID.", ex);
        }
    }

    /// <summary>
    /// Updates an existing Category object in the database based on the provided object and ID.
    /// </summary>
    /// <param name="obj">The Category object with updated information.</param>
    /// <param name="id">The ID of the Category object to update.</param>
    /// <returns>The updated Category object if successful, null if category with given id not found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during the operation.</exception>
    public Category? Update(Category obj, Guid id)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "Category object cannot be null.");

        if (id == Guid.Empty)
            throw new ArgumentException("Category ID cannot be empty.", nameof(id));

        try
        {
            var existingCategory = context.Set<Category>().FirstOrDefault(c => c.Id == id);
            if (existingCategory is null)
                return null;

            existingCategory.Name = obj.Name;
            existingCategory.Description = obj.Description;

            context.SaveChanges();
            return existingCategory;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating Category with ID {id}.", ex);
        }
    }
}

using Db.Models;

namespace Repositories.Interfaces;

/// <summary>
/// Interface for category repository providing CRUD operations for categories.
/// </summary>
public interface ICategoryRES
{
    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{Category}"/> containing all categories.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving categories.</exception>
    public IEnumerable<Category> Get();

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to retrieve.</param>
    /// <returns>The category if found; otherwise, null.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the category.</exception>
    public Category? GetById(Guid id);

    /// <summary>
    /// Adds a new category to the database.
    /// </summary>
    /// <param name="obj">The category to add to the database.</param>
    /// <returns>The added category.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while adding the category.</exception>
    public Category Add(Category obj);

    /// <summary>
    /// Updates an existing category in the database.
    /// </summary>
    /// <param name="obj">The updated category to save in the database.</param>
    /// <param name="id">The unique identifier of the category to be updated.</param>
    /// <returns>The updated category if the update was successful; null if category with given id not found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while updating the category.</exception>
    public Category? Update(Category obj, Guid id);

    /// <summary>
    /// Deletes an existing category from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the category to be deleted.</param>
    /// <returns>
    /// <c>true</c> if the category was successfully deleted; 
    /// <c>false</c> if no matching category was found.
    /// </returns>
    /// <exception cref="Exception">Thrown if an error occurs while deleting the category.</exception>
    public bool Delete(Guid id);
}

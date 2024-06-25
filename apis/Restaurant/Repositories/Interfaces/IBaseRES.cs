namespace Repositories.Interfaces;

/// <summary>
///     Base repositories with basic functions
///     T: Entity type
///     X: Id type
/// </summary>
public interface IBaseRES<T, X>
{
    /// <summary>
    ///     Retrieves all objects from the database.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> containing all objects.</returns>
    public IEnumerable<T> Get();



    /// <summary>
    ///     Retrieves an object by its ID.
    /// </summary>
    /// <param name="id">The ID of the object to retrieve.</param>
    /// <returns>The object if found; otherwise, null.</returns>
    public T? GetById(X id);



    /// <summary>
    ///     Adds a new object to the database.
    /// </summary>
    /// <param name="obj">The object to add to the database.</param>
    /// <returns>The added object, or <c>null</c> if the operation failed.</returns>
    public T? Add(T obj);



    /// <summary>
    ///     Updates an existing object in the database whose id matches the update id.
    /// </summary>
    /// <param name="obj">The updated object to save in the database.</param>
    /// <param name="id">The ID of the object to be updated.</param>
    /// <returns>The updated object if the update was successful, or <c>null</c> if no matching object was found or the operation failed.</returns>
    public T? Update(T obj, X id);



    /// <summary>
    ///     Deletes an existing object from the database whose id matches the specified id.
    /// </summary>
    /// <param name="id">The ID of the object to be deleted.</param>
    /// <returns>
    /// Returns <c>true</c> if the object was successfully deleted; 
    /// Returns <c>false</c> if no matching object was found; 
    /// Returns <c>null</c> if the deletion failed due to an error.
    /// </returns>
    public bool? Delete(X id);
}
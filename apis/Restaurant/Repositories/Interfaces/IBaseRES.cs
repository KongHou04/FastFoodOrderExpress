namespace Repositories.Interfaces;

/// <summary>
///     Base repositories with basic functions
/// </summary>
public interface IBaseRES
{
    /// <summary>
    ///     Get all objects from database
    /// </summary>
    /// <returns></returns>
    public IEnumerable<object> Get();

    /// <summary>
    ///     Get an object by searching by object id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public object? GetById(object? id);

    /// <summary>
    ///     Add a new object to database
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public object? Add(object? obj);

    /// <summary>
    ///     Update an existing object in the database whose id matches the update id
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public object? Update(object? obj, object id);

    /// <summary>
    ///     Delete an existing object from the database whose id matches the delete id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public object? Delete(object? id);
}
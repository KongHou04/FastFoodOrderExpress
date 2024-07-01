using Db.Models;

namespace Repositories.Interfaces;

/// <summary>
/// Interface for OrderDetails repository providing CRUD operations for order details.
/// </summary>
public interface IOrderDetailsRES
{
    /// <summary>
    /// Retrieves all order details for a specific order from the database.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order whose details to retrieve.</param>
    /// <returns>An <see cref="IEnumerable{OrderDetails}"/> containing the details of the specified order.</returns>
    public IEnumerable<OrderDetails> GetByOrder(Guid orderId);

    /// <summary>
    /// Retrieves an order detail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order detail to retrieve.</param>
    /// <returns>The order detail if found; otherwise, null.</returns>
    public OrderDetails? GetById(int id);

    /// <summary>
    /// Adds a new order detail to the database.
    /// </summary>
    /// <param name="obj">The order detail to add to the database.</param>
    /// <returns>The added order detail, or <c>null</c> if the operation failed.</returns>
    public OrderDetails? Add(OrderDetails obj);

    /// <summary>
    /// Updates an existing order detail in the database. Should not be used to update the status of the order.
    /// </summary>
    /// <param name="obj">The updated order detail to save in the database.</param>
    /// <param name="id">The unique identifier of the order detail to be updated.</param>
    /// <returns>The updated order detail if the update was successful, or <c>null</c> if no matching order detail was found or the operation failed.</returns>
    public OrderDetails? Update(OrderDetails obj, int id);

    /// <summary>
    /// Deletes an existing order detail from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the order detail to be deleted.</param>
    /// <returns>
    /// <c>true</c> if the order detail was successfully deleted; 
    /// <c>false</c> if no matching order detail was found; 
    /// <c>null</c> if the deletion failed due to an error.
    /// </returns>
    public bool? Delete(int id);
}

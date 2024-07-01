using Db.Models;

namespace Repositories.Interfaces;

/// <summary>
/// Interface for Order repository providing CRUD operations for orders.
/// </summary>
public interface IOrderRES
{
    /// <summary>
    /// Retrieves a specified number of orders from the database.
    /// </summary>
    /// <param name="numberOfOrder">The number of orders to retrieve.</param>
    /// <returns>An <see cref="IEnumerable{Order}"/> containing the specified number of orders.</returns>
    public IEnumerable<Order> Get(int numberOfOrder);

    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to retrieve.</param>
    /// <returns>The order if found; otherwise, null.</returns>
    public Order? GetById(Guid id);

    /// <summary>
    /// Retrieves orders by a specific user identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose orders to retrieve.</param>
    /// <returns>The orders of the specified user if found; otherwise, null.</returns>
    public Order? GetByUser(Guid userId);

    /// <summary>
    /// Adds a new order to the database.
    /// </summary>
    /// <param name="obj">The order to add to the database.</param>
    /// <returns>The added order, or <c>null</c> if the operation failed.</returns>
    public Order? Add(Order obj);

    /// <summary>
    /// Updates an existing order in the database. Should not use this to update status of the order.
    /// </summary>
    /// <param name="obj">The updated order to save in the database.</param>
    /// <param name="id">The unique identifier of the order to be updated.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found or the operation failed.</returns>
    public Order? Update(Order obj, Guid id);

    /// <summary>
    /// Updates the delivery status of an order.
    /// </summary>
    /// <param name="status">The new delivery status to set.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found or the operation failed.</returns>
    public Order? UpdateDeliveryStatus(int status, Guid id);

    /// <summary>
    /// Updates the payment status of an order.
    /// </summary>
    /// <param name="status">The new payment status to set.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found or the operation failed.</returns>
    public Order? UpdatePaymentStatus(int status, Guid id);

    /// <summary>
    /// Cancels an order.
    /// </summary>
    /// <param name="id">The unique identifier of the order to cancel.</param>
    /// <returns>The cancelled order if the operation was successful, or <c>null</c> if no matching order was found or the operation failed.</returns>
    public Order? Cancel(Guid id);

    /// <summary>
    /// Deletes an existing order from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the order to be deleted.</param>
    /// <returns>
    /// <c>true</c> if the order was successfully deleted; 
    /// <c>false</c> if no matching order was found; 
    /// <c>null</c> if the deletion failed due to an error.
    /// </returns>
    public bool? Delete(Guid id);
}

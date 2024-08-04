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
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the orders.</exception>
    public IEnumerable<Order> Get(int numberOfOrder);

    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to retrieve.</param>
    /// <returns>The order if found; otherwise, null.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the order.</exception>
    public Order? GetById(Guid id);

    /// <summary>
    /// Retrieves orders by a specific customer identifier.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer whose orders to retrieve.</param>
    /// <returns>The An <see cref="IEnumerable{Order}"/> of the specified customer if found</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the orders.</exception>
    public IEnumerable<Order> GetByCustomer(Guid customerId);

    /// <summary>
    /// Adds a new order to the database.
    /// </summary>
    /// <param name="obj">The order to add to the database.</param>
    /// <returns>The added order.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the adding order.</exception>
    public Order Add(Order obj);

    /// <summary>
    /// Updates an existing order in the database. Should not use this to update status of the order.
    /// </summary>
    /// <param name="obj">The updated order to save in the database.</param>
    /// <param name="id">The unique identifier of the order to be updated.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the updating order.</exception>
    public Order? Update(Order obj, Guid id);

    /// <summary>
    /// Updates the delivery status of an order.
    /// </summary>
    /// <param name="status">The new delivery status to set.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the updating order.</exception>
    public Order? UpdateDeliveryStatus(int status, Guid id);

    /// <summary>
    /// Updates the payment status of an order.
    /// </summary>
    /// <param name="status">The new payment status to set.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the updating order.</exception>
    public Order? UpdatePaymentStatus(int status, Guid id);

    /// <summary>
    /// Cancels an order.
    /// </summary>
    /// <param name="id">The unique identifier of the order to cancel.</param>
    /// <returns>The cancelled order if the operation was successful, or <c>null</c> if no matching order was found.</returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the updating order.</exception>
    public Order? Cancel(Guid id);

    /// <summary>
    /// Deletes an existing order from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the order to be deleted.</param>
    /// <returns>
    /// <c>true</c> if the order was successfully deleted; 
    /// <c>false</c> if no matching order was found; 
    /// </returns>
    /// <exception cref="Exception">Thrown if an error occurs while retrieving the deleting order.</exception>
    public bool Delete(Guid id);

    /// <summary>
    /// Updates the discount of an order.
    /// </summary>
    /// <param name="couponCode">The coupon code to apply.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found.</returns>
    Order? UpdateDiscount(Guid couponCode, Guid id);

    /// <summary>
    /// Updates the order details.
    /// </summary>
    /// <param name="obj">The updated order details to save in the database.</param>
    /// <param name="id">The unique identifier of the order to be updated.</param>
    /// <returns>The updated order if the update was successful, or <c>null</c> if no matching order was found.</returns>
    Order? UpdateOrderDetails(Order obj, Guid id);
}

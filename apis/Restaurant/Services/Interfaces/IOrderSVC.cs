using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for order services providing CRUD operations and validation for orders.
/// </summary>
public interface IOrderSVC
{
    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    /// <returns>A Response object containing the list of all orders and status information about the retrieval process.</returns>
    public Response Get();

    /// <summary>
    /// Retrieves a specific order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to retrieve.</param>
    /// <returns>A Response object containing the details of the specified order and status information about the retrieval process.</returns>
    public Response GetById(Guid id);

    /// <summary>
    /// Retrieves orders by a specific user identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose orders to retrieve.</param>
    /// <returns>A Response object containing the list of the specified user's order and status information about the retrieval process.</returns>
    public Response GetByUser(Guid id);

    /// <summary>
    /// Adds a new order.
    /// </summary>
    /// <param name="obj">The new order to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    public Response Add(Order obj);

    /// <summary>
    /// Updates an existing order, excluding order ID and order time.
    /// </summary>
    /// <param name="obj">The updated details of the order.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response Update(Order obj, Guid id);

    /// <summary>
    /// Updates order details for an existing order.
    /// </summary>
    /// <param name="obj">The updated details of the order.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response UpdateOrderDetails(Order obj, Guid id);

    /// <summary>
    /// Applies a discount to an existing order identified by its unique identifier.
    /// </summary>
    /// <param name="couponCode">The unique identifier of the coupon to apply as discount.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response UpdateDiscount(Guid couponCode, Guid id);

    /// <summary>
    /// Updates the delivery status of an existing order identified by its unique identifier.
    /// </summary>
    /// <param name="deliveryStatus">The new delivery status code.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response UpdateDeliveryStatus(int deliveryStatus, Guid id);

    /// <summary>
    /// Updates the payment status of an existing order identified by its unique identifier.
    /// </summary>
    /// <param name="paymentStatus">The new payment status code.</param>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response UpdatePaymentStatus(int paymentStatus, Guid id);

    /// <summary>
    /// Cancels an existing order identified by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to cancel.</param>
    /// <returns>A Response object indicating the result of the cancellation operation and status information about the process.</returns>
    public Response CancelOrder(Guid id);

    /// <summary>
    /// Deletes a specific order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    public Response Delete(Guid id);

    /// <summary>
    /// Validates an order, optionally checking for existence based on ID.
    /// </summary>
    /// <param name="obj">The order object to validate.</param>
    /// <param name="isIdCheck">True to perform ID existence check; False otherwise.</param>
    /// <returns>A list of validation messages indicating any errors or warnings during validation.</returns>
    public List<string> ValidateOrder(Order obj, bool isIdCheck);
}

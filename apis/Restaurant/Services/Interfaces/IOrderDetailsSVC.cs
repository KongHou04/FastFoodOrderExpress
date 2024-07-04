using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for order details services providing CRUD operations and validation for order details.
/// </summary>
public interface IOrderDetailsSVC
{
    /// <summary>
    /// Retrieves a specific order detail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order detail to retrieve.</param>
    /// <returns>A Response object containing the specified order detail and status information about the retrieval process.</returns>
    public Response GetById(int id);

    /// <summary>
    /// Retrieves all specific order details by order unique identifier.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order.</param>
    /// <returns>A Response object containing the order details of the specified order and status information about the retrieval process.</returns>
    public Response GetByOrder(Guid orderId);

    /// <summary>
    /// Adds a new order detail.
    /// </summary>
    /// <param name="obj">The new order detail to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    public Response Add(OrderDetails obj);

    /// <summary>
    /// Updates an existing order detail.
    /// </summary>
    /// <param name="obj">The updated details of the order detail.</param>
    /// <param name="id">The unique identifier of the order detail to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response Update(OrderDetails obj, int id);

    /// <summary>
    /// Deletes a specific order detail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order detail to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    public Response Delete(int id);

    /// <summary>
    /// Validates an order detail, optionally checking for existence based on ID.
    /// </summary>
    /// <param name="obj">The order detail object to validate.</param>
    /// <param name="isIdCheck">True to perform ID existence check; False otherwise.</param>
    /// <returns>A list of validation messages indicating any errors or warnings during validation.</returns>
    public List<string> ValidateOrder(OrderDetails obj, bool isIdCheck);
}

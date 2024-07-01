using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for order details services providing CRUD operations and validation for order details.
/// </summary>
public interface IOrderDetailsSVC
{
    /// <summary>
    /// Retrieves all order details.
    /// </summary>
    /// <returns>A Response object containing the list of all order details and status information about the retrieval process.</returns>
    public Response Get();

    /// <summary>
    /// Retrieves a specific order detail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order detail to retrieve.</param>
    /// <returns>A Response object containing the details of the specified order detail and status information about the retrieval process.</returns>
    public Response GetById(Guid id);

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
    public Response Update(OrderDetails obj, Guid id);

    /// <summary>
    /// Deletes a specific order detail by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order detail to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    public Response Delete(Guid id);

    /// <summary>
    /// Validates an order detail, optionally checking for existence based on ID.
    /// </summary>
    /// <param name="obj">The order detail object to validate.</param>
    /// <param name="isIdCheck">True to perform ID existence check; False otherwise.</param>
    /// <returns>A list of validation messages indicating any errors or warnings during validation.</returns>
    public List<string> ValidateOrder(OrderDetails obj, bool isIdCheck);
}

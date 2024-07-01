using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for coupon type services providing CRUD operations for coupon types.
/// </summary>
public interface ICouponTypeSVC
{
    /// <summary>
    /// Retrieves all coupon types.
    /// </summary>
    /// <returns>A Response object containing the list of all coupon types and status information about the retrieval process.</returns>
    public Response Get();

    /// <summary>
    /// Retrieves a specific coupon type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the coupon type to retrieve.</param>
    /// <returns>A Response object containing the details of the specified coupon type and status information about the retrieval process.</returns>
    public Response GetById(int id);

    /// <summary>
    /// Adds a new coupon type.
    /// </summary>
    /// <param name="obj">The new coupon type to add.</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    public Response Add(CouponType obj);

    /// <summary>
    /// Updates an existing coupon type.
    /// </summary>
    /// <param name="obj">The updated details of the coupon type.</param>
    /// <param name="id">The unique identifier of the coupon type to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response Update(CouponType obj, int id);

    /// <summary>
    /// Deletes a specific coupon type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the coupon type to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    public Response Delete(int id);
}

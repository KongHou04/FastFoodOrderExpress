using Db.Models;
using Models;

namespace Services.Interfaces;

/// <summary>
/// Interface for coupon services providing CRUD operations and actions related to coupons.
/// </summary>
public interface ICouponSVC
{
    /// <summary>
    /// Retrieves valid coupons for a specific user identified by their unique identifier.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>A Response object containing the list of valid coupons for the user and status information about the retrieval process.</returns>
    public Response GetValidByCustomer(Guid customerId);

    /// <summary>
    /// Retrieves all coupons for a specific user identified by their unique identifier.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>A Response object containing the list of all coupons for the user and status information about the retrieval process.</returns>
    public Response GetByCustomer(Guid customerId);

    /// <summary>
    /// Retrieves a specific coupon by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the coupon to retrieve.</param>
    /// <returns>A Response object containing the details of the specified coupon and status information about the retrieval process.</returns>
    public Response GetById(Guid id);

    /// <summary>
    /// Adds a new coupon of a specified type and optional quantity.
    /// </summary>
    /// <param name="couponTypeId">The unique identifier of the coupon type to add.</param>
    /// <param name="quantity">The quantity of coupons to add (default is 1).</param>
    /// <returns>A Response object indicating the result of the add operation and status information about the add process.</returns>
    public Response Add(int couponTypeId, int quantity = 20);

    /// <summary>
    /// Updates an existing coupon. This is not recommend
    /// </summary>
    /// <param name="obj">The updated details of the coupon.</param>
    /// <param name="id">The unique identifier of the coupon to update.</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response Update(Coupon obj, Guid id);

    /// <summary>
    /// Give user the quantity of coupon in a specific coupon type
    /// </summary>
    /// <param name="couponType">The unique identifier of the coupon type to give.</param>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="quantity">The quantity of coupons given (default is 1).</param>
    /// <returns>A Response object indicating the result of the update operation and status information about the update process.</returns>
    public Response UpdateUser(int couponType, Guid userId, int quantity = 1);

    /// <summary>
    /// Deletes a specific coupon by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the coupon to delete.</param>
    /// <returns>A Response object indicating the result of the delete operation and status information about the delete process.</returns>
    public Response Delete(Guid id);
}

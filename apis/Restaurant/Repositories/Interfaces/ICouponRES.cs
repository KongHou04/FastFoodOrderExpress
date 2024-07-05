using Db.Models;
using System;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for Coupon repository providing CRUD operations for coupons.
    /// </summary>
    public interface ICouponRES
    {
        /// <summary>
        /// Retrieves a coupon by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to retrieve.</param>
        /// <returns>The coupon if found; otherwise, null.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public Coupon? GetById(Guid id);

        /// <summary>
        /// Retrieves all coupons for a specific user from the database.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>An <see cref="IEnumerable{Coupon}"/> containing all coupons for the specified user.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public IEnumerable<Coupon> GetByCustomer(Guid customerId);

        /// <summary>
        /// Adds a new coupon to the database.
        /// </summary>
        /// <param name="couponTypeId">The coupon type identifier to add coupons.</param>
        /// <param name="number">The number of coupons to add.</param>
        /// <returns><c>true</c> if the coupons were successfully added; otherwise, <c>false</c>.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public bool Add(int couponTypeId, int number = 20);

        /// <summary>
        /// Updates an existing coupon in the database.
        /// </summary>
        /// <param name="coupon">The updated coupon to save in the database.</param>
        /// <param name="id">The unique identifier of the coupon to be updated.</param>
        /// <returns>The updated coupon if the update was successful, or <c>null</c> if no matching coupon was found.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public Coupon? Update(Coupon obj, Guid id);

        /// <summary>
        /// Deletes an existing coupon from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to be deleted.</param>
        /// <returns><c>true</c> if the coupon was successfully deleted; <c>false</c> if no matching coupon was found.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public bool Delete(Guid id);
    }
}

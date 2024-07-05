using Db.Models;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for CouponType repository providing CRUD operations for coupon types.
    /// </summary>
    public interface ICouponTypeRES
    {
        /// <summary>
        /// Retrieves all coupon types from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{CouponType}"/> containing all coupon types.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public IEnumerable<CouponType> Get();

        /// <summary>
        /// Retrieves a coupon type by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon type to retrieve.</param>
        /// <returns>The coupon type if found; otherwise, null.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public CouponType? GetById(int id);

        /// <summary>
        /// Adds a new coupon type to the database.
        /// </summary>
        /// <param name="obj">The coupon type to add to the database.</param>
        /// <returns>The added coupon type.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public CouponType Add(CouponType obj);

        /// <summary>
        /// Updates an existing coupon type in the database.
        /// </summary>
        /// <param name="obj">The updated coupon type to save in the database.</param>
        /// <param name="id">The unique identifier of the coupon type to be updated.</param>
        /// <returns>The updated coupon type if the update was successful, or <c>null</c> if no matching coupon type was found.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public CouponType? Update(CouponType obj, int id);

        /// <summary>
        /// Deletes an existing coupon type from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon type to be deleted.</param>
        /// <returns>
        /// <c>true</c> if the coupon type was successfully deleted; 
        /// <c>false</c> if no matching coupon type was found.
        /// </returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public bool Delete(int id);
    }
}

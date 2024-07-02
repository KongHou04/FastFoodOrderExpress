using Db.Models;
using System;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for ComboDetails repository providing CRUD operations for combo details.
    /// </summary>
    public interface IComboDetailsRES
    {
        /// <summary>
        /// Retrieves all combo details for a specific product from the database.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <returns>An <see cref="IEnumerable{ComboDetails}"/> containing all combo details for the specified product.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public IEnumerable<ComboDetails> GetByProduct(Guid productId);

        /// <summary>
        /// Retrieves a combo detail by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the combo detail to retrieve.</param>
        /// <returns>The combo detail if found; otherwise, null.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public ComboDetails? GetById(int id);

        /// <summary>
        /// Adds a new combo detail to the database.
        /// </summary>
        /// <param name="obj">The combo detail to add to the database.</param>
        /// <returns>The added combo detail.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public ComboDetails? Add(ComboDetails obj);

        /// <summary>
        /// Updates an existing combo detail in the database.
        /// </summary>
        /// <param name="obj">The updated combo detail to save in the database.</param>
        /// <param name="id">The unique identifier of the combo detail to be updated.</param>
        /// <returns>The updated combo detail if the update was successful, or <c>null</c> if no matching combo detail was found.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public ComboDetails? Update(ComboDetails obj, int id);

        /// <summary>
        /// Deletes an existing combo detail from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the combo detail to be deleted.</param>
        /// <returns>
        /// <c>true</c> if the combo detail was successfully deleted; 
        /// <c>false</c> if no matching combo detail was found; 
        /// </returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public bool Delete(int id);
    }
}

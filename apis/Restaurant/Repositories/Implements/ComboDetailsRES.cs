using Db.Contexts;
using Db.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Implements
{
    /// <summary>
    /// Repository implementation for handling CRUD operations on ComboDetails entities.
    /// </summary>
    public class ComboDetailsRES : BaseRES, IComboDetailsRES
    {
        /// <summary>
        /// Constructor that initializes the repository with an instance of the database context.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public ComboDetailsRES(FFOEContext context) : base(context)
        {
        }

        /// <summary>
        /// Adds a new ComboDetails object to the database.
        /// </summary>
        /// <param name="obj">The ComboDetails object to add.</param>
        /// <returns>The added ComboDetails object.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public ComboDetails? Add(ComboDetails obj)
        {
            try
            {
                var entry = context.ComboDetails.Add(obj);
                context.SaveChanges();
                return entry.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding combo detail.", ex);
            }
        }

        /// <summary>
        /// Deletes a ComboDetails object from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the ComboDetails object to delete.</param>
        /// <returns>True if the ComboDetails object was successfully deleted; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public bool Delete(int id)
        {
            try
            {
                var comboDetail = context.ComboDetails.Find(id);

                if (comboDetail == null)
                    return false;

                context.ComboDetails.Remove(comboDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting combo detail.", ex);
            }
        }

        /// <summary>
        /// Retrieves all ComboDetails associated with a specific product from the database.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve ComboDetails for.</param>
        /// <returns>An IEnumerable of ComboDetails objects.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public IEnumerable<ComboDetails> GetByProduct(Guid productId)
        {
            try
            {
                var comboDetails = context.ComboDetails
                    .Where(cd => cd.ProductId == productId)
                    .ToList();

                return comboDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving combo details by product ID.", ex);
            }
        }

        /// <summary>
        /// Retrieves a ComboDetails object from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the ComboDetails object to retrieve.</param>
        /// <returns>The retrieved ComboDetails object, or null if not found.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public ComboDetails? GetById(int id)
        {
            try
            {
                var comboDetail = context.ComboDetails.Find(id);
                return comboDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving combo detail by ID.", ex);
            }
        }

        /// <summary>
        /// Updates an existing ComboDetails object in the database.
        /// </summary>
        /// <param name="obj">The updated ComboDetails object.</param>
        /// <param name="id">The ID of the ComboDetails object to update.</param>
        /// <returns>The updated ComboDetails object if successful, or null if the object with the given ID was not found.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the operation.</exception>
        public ComboDetails? Update(ComboDetails obj, int id)
        {
            try
            {
                var existingComboDetail = context.ComboDetails.FirstOrDefault(cd => cd.Id == id);

                if (existingComboDetail == null)
                    return null;

                existingComboDetail.ProductId = obj.ProductId;
                existingComboDetail.Quantity = obj.Quantity;

                context.SaveChanges();
                return existingComboDetail;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating combo detail with ID {id}.", ex);
            }
        }
    }
}

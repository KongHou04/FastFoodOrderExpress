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
    /// Repository implementation for managing product discounts.
    /// </summary>
    public class ProductDiscountRES : BaseRES, IProductDiscountRES
    {
        public ProductDiscountRES(FFOEContext context) : base(context)
        {
        }

        /// <summary>
        /// Adds a new product discount to the database.
        /// </summary>
        /// <param name="obj">The product discount to add.</param>
        /// <returns>The added product discount entity.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while adding the product discount.</exception>
        public ProductDiscount Add(ProductDiscount obj)
        {
            try
            {
                var entry = context.ProductDiscounts.Add(obj);
                context.SaveChanges();

                return entry.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product discount.", ex);
            }
        }

        /// <summary>
        /// Deletes a product discount from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the product discount to delete.</param>
        /// <returns>True if the product discount was deleted successfully; otherwise, false.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while deleting the product discount.</exception>
        public bool Delete(int id)
        {
            try
            {
                var productDiscount = context.ProductDiscounts.Find(id);

                if (productDiscount == null)
                    return false;

                context.ProductDiscounts.Remove(productDiscount);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product discount.", ex);
            }
        }

        /// <summary>
        /// Retrieves all product discounts for a specific product from the database.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>An enumerable collection of product discounts.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving product discounts.</exception>
        public IEnumerable<ProductDiscount> GetByProduct(Guid productId)
        {
            try
            {
                var productDiscounts = context.ProductDiscounts
                    .Where(pd => pd.ProductId == productId)
                    .ToList();

                return productDiscounts;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product discounts by product ID.", ex);
            }
        }

        /// <summary>
        /// Retrieves a product discount by its ID.
        /// </summary>
        /// <param name="id">The ID of the product discount to retrieve.</param>
        /// <returns>The product discount entity if found; otherwise, null.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving the product discount.</exception>
        public ProductDiscount? GetById(int id)
        {
            try
            {
                var productDiscount = context.ProductDiscounts.Find(id);
                return productDiscount;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product discount by ID.", ex);
            }
        }

        /// <summary>
        /// Updates an existing product discount in the database.
        /// </summary>
        /// <param name="obj">The updated product discount entity.</param>
        /// <param name="id">The ID of the product discount to update.</param>
        /// <returns>The updated product discount entity if the update was successful; otherwise, null.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while updating the product discount.</exception>
        public ProductDiscount? Update(ProductDiscount obj, int id)
        {
            try
            {
                var existingProductDiscount = context.ProductDiscounts.FirstOrDefault(pd => pd.Id == id);

                if (existingProductDiscount == null)
                    return null;

                existingProductDiscount.PercentValue = obj.PercentValue;
                existingProductDiscount.HardValue = obj.HardValue;
                existingProductDiscount.StartTime = obj.StartTime;
                existingProductDiscount.EndTime = obj.EndTime;

                context.SaveChanges();
                return existingProductDiscount;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product discount with ID {id}.", ex);
            }
        }
    }
}

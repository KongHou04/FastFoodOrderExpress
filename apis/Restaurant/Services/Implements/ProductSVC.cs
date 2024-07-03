using Db.Models;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements
{
    /// <summary>
    /// Service implementation for handling operations related to products.
    /// </summary>
    public class ProductSVC(IProductRES productRES) : IProductSVC
    {
        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="obj">The product to add.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        public Response Add(Product obj)
        {
            try
            {
                var addedObj = productRES.Add(obj);
                return new Response(true, "Added new product successfully.", addedObj);
            }
            catch (Exception ex)
            {
                return new Response(false, "Error occurred while adding the new product.", null, new List<string> { ex.Message });
            }
        }

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        public Response Delete(Guid id)
        {
            try
            {
                var isDeleted = productRES.Delete(id);
                if (isDeleted)
                    return new Response(true, "Deleted product successfully.", isDeleted);
                else
                    return new Response(true, "No product with the given ID found.");
            }
            catch (Exception ex)
            {
                return new Response(false, "Error occurred while deleting the product with the given ID.", null, new List<string> { ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A response containing the list of all products.</returns>
        public Response Get()
        {
            try
            {
                var data = productRES.Get();
                return new Response(true, "Retrieved all products successfully.", data);
            }
            catch (Exception ex)
            {
                return new Response(false, "Error occurred while retrieving all products.", null, new List<string> { ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>A response containing the product details.</returns>
        public Response GetById(Guid id)
        {
            try
            {
                var existingObj = productRES.GetById(id);
                return new Response(true, "Retrieved the product by ID successfully.", existingObj);
            }
            catch (Exception ex)
            {
                return new Response(false, "Error occurred while retrieving the product by ID.", null, new List<string> { ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing product by its unique identifier.
        /// </summary>
        /// <param name="obj">The product details to update.</param>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        public Response Update(Product obj, Guid id)
        {
            try
            {
                var result = productRES.Update(obj, id);
                return new Response(true, "Updated the product by ID successfully.", result);
            }
            catch (Exception ex)
            {
                return new Response(false, "Error occurred while updating the product with the given ID.", null, new List<string> { ex.Message });
            }
        }
    }
}

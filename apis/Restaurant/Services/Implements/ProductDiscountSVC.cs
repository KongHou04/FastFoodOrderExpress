using Db.Models;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements;

public class ProductDiscountSVC(IProductDiscountRES productDiscountRES) : IProductDiscountSVC
{
    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="obj">The product to add.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    public Response Add(ProductDiscount obj)
    {
        try
        {
            var addedObj = productDiscountRES.Add(obj);
            return new Response(true, "Added new product discount successfully.", addedObj);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while adding the new product discount.", null, new List<string> { ex.Message });
        }
    }

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    public Response Delete(int id)
    {
        try
        {
            var isDeleted = productDiscountRES.Delete(id);
            if (isDeleted)
                return new Response(true, "Deleted product discount successfully.", isDeleted);
            else
                return new Response(true, "No product discount with the given ID found.");
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while deleting the product discount with the given ID.", null, new List<string> { ex.Message });
        }
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A response containing the list of all products.</returns>
    public Response GetByProduct(Guid productId)
    {
        try
        {
            var data = productDiscountRES.GetByProduct(productId);
            return new Response(true, "Retrieved all product discounts of the product successfully.", data);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while retrieving all product discount of the product.", null, new List<string> { ex.Message });
        }
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve.</param>
    /// <returns>A response containing the product details.</returns>
    public Response GetById(int id)
    {
        try
        {
            var existingObj = productDiscountRES.GetById(id);
            return new Response(true, "Retrieved the product discount by ID successfully.", existingObj);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while retrieving the product discount by ID.", null, new List<string> { ex.Message });
        }
    }

    /// <summary>
    /// Updates an existing product by its unique identifier.
    /// </summary>
    /// <param name="obj">The product details to update.</param>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    public Response Update(ProductDiscount obj, int id)
    {
        try
        {
            var result = productDiscountRES.Update(obj, id);
            return new Response(true, "Updated the product discount by ID successfully.", result);
        }
        catch (Exception ex)
        {
            return new Response(false, "Error occurred while updating the product discount with the given ID.", null, new List<string> { ex.Message });
        }
    }
}
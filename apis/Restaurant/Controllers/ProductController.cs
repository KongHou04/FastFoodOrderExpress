using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    /// <summary>
    /// API Controller for handling product-related operations.
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductController(IProductSVC productSVC) : ControllerBase
    {
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A response containing the list of all products.</returns>
        [HttpGet]
        public Response Get()
        {
            return productSVC.Get();
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>A response containing the product details.</returns>
        [HttpGet("{id}")]
        public Response GetById([FromRoute] Guid id)
        {
            return productSVC.GetById(id);
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="obj">The product to add.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPost]
        public Response Add(Product obj)
        {
            return productSVC.Add(obj);
        }

        /// <summary>
        /// Updates an existing product by its unique identifier.
        /// </summary>
        /// <param name="obj">The product details to update.</param>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpPut]
        public Response Update(Product obj, Guid id)
        {
            return productSVC.Update(obj, id);
        }

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        [HttpDelete]
        public Response Delete(Guid id)
        {
            return productSVC.Delete(id);
        }
    }
}

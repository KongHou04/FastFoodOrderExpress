using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/coupons")]
    public class CouponController(ICouponSVC couponSVC) : ControllerBase
    {
        [HttpGet("{id}")]
        public Response GetById([FromRoute]Guid id)
        {
            return couponSVC.GetById(id);
        }

        [HttpGet("customer/{id}")]
        public Response GetByCustomer([FromRoute] Guid customerId)
        {
            return couponSVC.GetByCustomer(customerId);
        }

        [HttpGet("customer/valid/{id}")]
        public Response GetValidByCustomer([FromRoute] Guid customerId)
        {
            return couponSVC.GetValidByCustomer(customerId);
        }

        [HttpPost("{couponTypeId}")]
        public Response Add([FromRoute]int couponTypeId, [FromBody]int quantity = 20)
        {
            return couponSVC.Add(couponTypeId, quantity);
        }

        [HttpPut("{id}")]
        public Response Update([FromBody] Coupon obj, [FromRoute] Guid id)
        {
            return couponSVC.Update(obj, id);
        }

        [HttpDelete("{id}")]
        public Response Delete([FromBody] Guid id)
        {
            return couponSVC.Delete(id);
        }
    }
}

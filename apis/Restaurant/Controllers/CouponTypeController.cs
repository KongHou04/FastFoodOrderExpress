using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("api/coupontypes")]
    public class CouponTypeController(ICouponTypeSVC couponTypeSVC) : ControllerBase
    {
        [HttpGet()]
        public Response Get()
        {
            return couponTypeSVC.Get();
        }

        [HttpGet("{id}")]
        public Response Get(int id)
        {
            return couponTypeSVC.GetById(id);
        }

        [HttpPost()]
        public Response Add(CouponType obj)
        {
            return couponTypeSVC.Add(obj);
        }

        [HttpPut("{id}")]
        public Response Udpate([FromBody]CouponType obj, [FromRoute] int id)
        {
            return couponTypeSVC.Update(obj, id);
        }

        [HttpDelete("{id}")]
        public Response Delete([FromRoute] int id)
        {
            return couponTypeSVC.Delete(id);
        }




    }
}

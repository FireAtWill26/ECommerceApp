using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Models.Request;

namespace ShippingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperServiceAsync shipperServiceAsync;

        public ShipperController(IShipperServiceAsync shipperServiceAsync)
        {
            this.shipperServiceAsync = shipperServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await shipperServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ShipperRequestModel shipperRequestModel)
        {
            return Ok(await shipperServiceAsync.Insert(shipperRequestModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ShipperRequestModel shipperRequestModel, int id)
        {
            return Ok(await shipperServiceAsync.Update(shipperRequestModel, id));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await shipperServiceAsync.GetById(id));
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await shipperServiceAsync.Delete(id));
        }


        [HttpGet]
        [Route("region/{region}")]
        public async Task<IActionResult> GetByRegion(int region)
        {
            return Ok(await shipperServiceAsync.GetByRegion(region));
        }
    }
}

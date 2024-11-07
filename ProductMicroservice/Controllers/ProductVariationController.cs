
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationServiceAsync ProductVariationServiceAsync;

        public ProductVariationController(IProductVariationServiceAsync ProductVariationServiceAsync)
        {
            this.ProductVariationServiceAsync = ProductVariationServiceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductVariationRequestModel productVariationRequestModel)
        {
            return Ok(await ProductVariationServiceAsync.Insert(productVariationRequestModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductVariation()
        {
            return Ok(await ProductVariationServiceAsync.GetAll());
        }
    }
}

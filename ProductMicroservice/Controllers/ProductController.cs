using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync ProductServiceAsync;

        public ProductController(IProductServiceAsync ProductServiceAsync)
        {
            this.ProductServiceAsync = ProductServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts()
        {
            return Ok(await ProductServiceAsync.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await ProductServiceAsync.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductRequestModel productRequestModel)
        {
            return Ok(await ProductServiceAsync.Insert(productRequestModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestModel productRequestMosdel, int id)
        {
            return Ok(await ProductServiceAsync.Update(productRequestMosdel, id));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            return Ok(await ProductServiceAsync.GetByCategoryId(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            return Ok(await ProductServiceAsync.GetByName(name));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await ProductServiceAsync.Delete(id));
        }
    }
}

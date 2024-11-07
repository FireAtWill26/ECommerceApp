using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationServiceAsync CategoryVariationServiceAsync;

        public CategoryVariationController(ICategoryVariationServiceAsync CategoryVariationServiceAsync)
        {
            this.CategoryVariationServiceAsync = CategoryVariationServiceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> Save(CategoryVariationRequestModel CategoryVariationRequestModel)
        {
            return Ok(await CategoryVariationServiceAsync.Insert(CategoryVariationRequestModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await CategoryVariationServiceAsync.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            return Ok(await CategoryVariationServiceAsync.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationByParentCategoryId(int id)
        {
            return Ok(await CategoryVariationServiceAsync.GetByCategoryId(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await CategoryVariationServiceAsync.Delete(id));
        }
    }
}

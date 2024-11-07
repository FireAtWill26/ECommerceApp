using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync categoryServiceAsync)
        {
            this.categoryServiceAsync = categoryServiceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryRequestModel categoryRequestModel)
        {
            return Ok(await categoryServiceAsync.Insert(categoryRequestModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await categoryServiceAsync.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await categoryServiceAsync.GetById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await categoryServiceAsync.Delete(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryByParentCategory(int id)
        {
            return Ok(await categoryServiceAsync.GetByParentId(id));
        }
    }
}

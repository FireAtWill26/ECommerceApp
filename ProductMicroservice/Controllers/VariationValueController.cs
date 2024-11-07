using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueServiceAsync VariationValueServiceAsync;

        public VariationValueController(IVariationValueServiceAsync VariationValueServiceAsync)
        {
            this.VariationValueServiceAsync = VariationValueServiceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> Save(VariationValueRequestModel VariationValueRequestModel)
        {
            return Ok(await VariationValueServiceAsync.Insert(VariationValueRequestModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetVariationId()
        {
            return Ok(await VariationValueServiceAsync.GetAll());
        }
    }
}

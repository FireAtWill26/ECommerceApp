using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionsMicroservice.ApplicationCore.Contracts.Services;
using PromotionsMicroservice.ApplicationCore.Models.Request;

namespace PromotionsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionServiceAsync promotionServiceAsync;

        public PromotionController(IPromotionServiceAsync promotionServiceAsync)
        {
            this.promotionServiceAsync = promotionServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await promotionServiceAsync.GetAllAsync());
        }

        [HttpPost] 
        public async Task<IActionResult> Insert(PromotionRequestModel promotionRequestModel)
        {
            return Ok(await promotionServiceAsync.Insert(promotionRequestModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PromotionRequestModel promotionRequestModel, int id)
        {
            return Ok(await promotionServiceAsync.Update(promotionRequestModel, id));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await promotionServiceAsync.GetById(id));
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await promotionServiceAsync.Delete(id));
        }

        [HttpGet]
        [Route("promotionByProductName")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await promotionServiceAsync.GetByName(name));
        }

        [HttpGet]
        [Route("activePromotions")]
        public async Task<IActionResult> GetActive()
        {
            return Ok(await promotionServiceAsync.GetActive());
        }
    }
}

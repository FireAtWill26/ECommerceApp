using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewMicroservice.ApplicationCore.Contracts.Services;
using ReviewMicroservice.ApplicationCore.Models.Request;
using ReviewMicroservice.Infrastructure.Services;

namespace ReviewMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly IReviewServiceAsync reviewServiceAsync;

        public CustomerReviewController(IReviewServiceAsync reviewServiceAsync)
        {
            this.reviewServiceAsync = reviewServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await reviewServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CustomerReviewRequestModel customerReviewRequestModel)
        {
            return Ok(await reviewServiceAsync.Insert(customerReviewRequestModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerReviewRequestModel customerReviewRequestModel, int id)
        {
            return Ok(await reviewServiceAsync.Update(customerReviewRequestModel, id));
        }

        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await reviewServiceAsync.Delete(id));
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await reviewServiceAsync.GetById(id));
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetByCustomer(int userId)
        {
            return Ok(await reviewServiceAsync.GetByCustomer(userId));
        }

        [HttpGet]
        [Route("product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            return Ok(await reviewServiceAsync.GetByProduct(productId));
        }

        [HttpGet]
        [Route("year/{year}")]
        public async Task<IActionResult> GetByYear(int year)
        {
            return Ok(await reviewServiceAsync.GetByYear(year));
        }

    }
}

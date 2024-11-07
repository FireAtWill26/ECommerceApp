using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Model.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceAsync paymentServiceAsync;
        public PaymentController(IPaymentServiceAsync paymentServiceAsync)
        {
            this.paymentServiceAsync = paymentServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentByCustomerId(int customerId)
        {
            return Ok(await paymentServiceAsync.GetByCustomerId(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> SavePayment(PaymentMethodRequestModel paymentMethodRequestModel)
        {
            return Ok(await paymentServiceAsync.Insert(paymentMethodRequestModel));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            return Ok(await paymentServiceAsync.Delete(id));
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePayment(int id, PaymentMethodRequestModel paymentMethodRequestModel)
        {
            return Ok(await paymentServiceAsync.Update(paymentMethodRequestModel, id));
        }
    }
}

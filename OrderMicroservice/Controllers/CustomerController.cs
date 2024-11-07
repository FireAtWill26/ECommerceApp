using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Model.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            this.customerServiceAsync = customerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAddressByUserId(string userId)
        {
            return Ok(await customerServiceAsync.GetCustomerAddressByUserId(userId));
        }


        [HttpPost]
        public async Task<IActionResult> SaveCustomerAddress(int customerId, AddressRequestModel addressRequestModel)
        {
            return Ok(await customerServiceAsync.SaveCustomerAddress(customerId, addressRequestModel));
        }
    }
}

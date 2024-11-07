using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Model.Request;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartServiceAsync shoppingCartServiceAsync;
        public ShoppingCartController(IShoppingCartServiceAsync shoppingCartServiceAsync)
        {
            this.shoppingCartServiceAsync = shoppingCartServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCartByCustomerId(int customerId)
        {
            return Ok(await shoppingCartServiceAsync.GetByCustomerId(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveShoppingCart(ShoppingCartRequestModel shoppingCartRequestModel)
        {
            return Ok(await shoppingCartServiceAsync.Insert(shoppingCartRequestModel));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            return Ok(await shoppingCartServiceAsync.Delete(id));
        }
    }
}

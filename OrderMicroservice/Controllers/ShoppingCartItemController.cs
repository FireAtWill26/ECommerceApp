using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemServiceAsync shoppingCartItemServiceAsync;

        public ShoppingCartItemController(IShoppingCartItemServiceAsync shoppingCartItemServiceAsync)
        {
            this.shoppingCartItemServiceAsync = shoppingCartItemServiceAsync;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartItemById(int shoppingCartItemId)
        {
            return Ok(await shoppingCartItemServiceAsync.Delete(shoppingCartItemId));
        }

    }
}

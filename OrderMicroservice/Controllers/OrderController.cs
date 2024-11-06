
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using RabbitMqHelper;
using System.Text.Json;
using System.Xml.Linq;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderServiceAsync orderServiceAsync;
        private readonly MessageQueue messageQueue;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            this.orderServiceAsync = orderServiceAsync;
            messageQueue = new MessageQueue("amqp://guest:guest@host.docker.internal:5672", "Order Microservice"); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await orderServiceAsync.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewOrder(OrderRequestModel orderRequestModel)
        {
            return Ok(await orderServiceAsync.InsertOrder(orderRequestModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            return Ok(await orderServiceAsync.GetOrderByCustomerId(customerId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if(await orderServiceAsync.DeleteOrder(id) == 0)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrder(OrderRequestModel orderRequestModel, int id)
        {
            return Ok(orderServiceAsync.UpdateOrder(orderRequestModel, id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderResponseModel model)
        {
            var str = JsonConvert.SerializeObject(model);
            await messageQueue.AddMessageToQueue(str, "OrderExchange", "OrderQueue", "custom-routing-key");
            return Ok("Message has been added to the queue.");
        }
    }
}

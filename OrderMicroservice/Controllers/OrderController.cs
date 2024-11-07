
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using RabbitMqHelper;
using System.Text.Json;
using System.Xml.Linq;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderServiceAsync orderServiceAsync;
        private readonly MessageQueue messageQueue;
        private readonly IMapper mapper;

        public OrderController(IOrderServiceAsync orderServiceAsync, IMapper mapper)
        {
            this.orderServiceAsync = orderServiceAsync;
            messageQueue = new MessageQueue("amqp://guest:guest@host.docker.internal:5672", "Order Microservice");
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await orderServiceAsync.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderRequestModel orderRequestModel)
        {
            return Ok(await orderServiceAsync.InsertOrder(orderRequestModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            return Ok(await orderServiceAsync.GetOrderByCustomerId(customerId));
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderStatus(int id)
        {
            return Ok((await orderServiceAsync.GetOrderById(id)).Order_Status);
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


        [HttpPut]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var model = await orderServiceAsync.GetOrderById(id);
            model.Order_Status = "Cancelled";
            var order = mapper.Map<Order>(model);
            var result = mapper.Map<OrderRequestModel>(order);
            return Ok(orderServiceAsync.UpdateOrder(result, id));
        }

        [HttpPut]
        public async Task<IActionResult> OrderCompleted(int id)
        {
            var model = await orderServiceAsync.GetOrderById(id);
            model.Order_Status = "Completed";
            var order = mapper.Map<Order>(model);
            var result = mapper.Map<OrderRequestModel>(order);
            return Ok(orderServiceAsync.UpdateOrder(result, id));
        }

        [HttpPut]
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

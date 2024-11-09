using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;

namespace ShippingMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingDetailServiceAsync _shippingDetailService;
        private readonly IMapper mapper;

        public ShippingController(IShippingDetailServiceAsync shippingDetailService, IMapper mapper)
        {
            _shippingDetailService = shippingDetailService;
            this.mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> ShippingCompleted(int id)
        {
            var model = mapper.Map<ShippingDetailRequestModel>(
                mapper.Map<ShippingDetail>((await _shippingDetailService.GetById(id))));
            model.shippingStatus = "Completed";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://host.docker.internal:53358/api/");
            await client.PostAsync($"Order/OrderCompleted?id={model.orderId}", null);
            return Ok(await _shippingDetailService.Update(model, id));
        }
    }
}

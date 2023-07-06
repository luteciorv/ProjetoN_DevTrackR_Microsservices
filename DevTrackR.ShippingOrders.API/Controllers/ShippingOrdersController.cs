using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [Route("api/envio-de-pedidos")]
    [ApiController]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _service;

        public ShippingOrdersController(IShippingOrderService shippingOrderService)
        {
            _service = shippingOrderService;
        }


        [HttpGet("{trackingCode}")]
        public async Task<IActionResult> GetByTrackingCode(string trackingCode) =>
            Ok(await _service.GetByTrackingCodeAsync(trackingCode));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddShippingOrderInputModel inputModel)
        {
            string trackingCode = await _service.AddAsync(inputModel);
            return CreatedAtAction(nameof(GetByTrackingCode), new { trackingCode }, inputModel);
        }
    }
}

using DevTrackR.ShippingOrders.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [Route("api/servicos-entrega")]
    public class ShippingServiceController : ControllerBase
    {
        private readonly IShippingService _service;

        public ShippingServiceController(IShippingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shippingServicesViewModel = await _service.GetAllAsync();
            return Ok(shippingServicesViewModel);
        }
    }
}

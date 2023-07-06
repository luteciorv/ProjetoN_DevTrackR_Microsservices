﻿using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.ShippingOrders.API.Controllers
{
    [Route("api/envio-de-pedidos")]
    [ApiController]
    public class ShippingOrdersController : ControllerBase
    {
        private readonly IShippingOrderService _shippingOrderService;

        public ShippingOrdersController(IShippingOrderService shippingOrderService)
        {
            _shippingOrderService = shippingOrderService;
        }


        [HttpGet("{trackingCode}")]
        public async Task<IActionResult> GetByTrackingCode(string trackingCode) =>
            Ok(await _shippingOrderService.GetByTrackingCodeAsync(trackingCode));

        [HttpPost]
        public IActionResult Post([FromBody] AddShippingOrderInputModel inputModel)
        {
            var trackingCode = _shippingOrderService.Add(inputModel);
            return CreatedAtAction(nameof(GetByTrackingCode), new { trackingCode }, inputModel);
        }
    }
}
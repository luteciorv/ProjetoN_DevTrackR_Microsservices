using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.Services.Interfaces;
using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingOrderService : IShippingOrderService
    {
        public string Add(AddShippingOrderInputModel inputModel)
        {
            var shippingOrder = inputModel.ToEntity();
            var shippingServices = inputModel.Services.Select(serviceInputModel => serviceInputModel.ToEntity()).ToList();
            
            shippingOrder.AddServices(shippingServices);

            return shippingOrder.TrackingCode;
        }

        public Task<ShippingOrderViewModel> GetByTrackingCodeAsync(string trackingCode)
        {
            var address = new DeliveryAddress("Rua A", "1A", "123456", "Cidade B", "Estado C", "País D");
            var details = new ShippingOrderDetails("Pedido 1", 1.3m, address);
            var shippingOrder = new ShippingOrder(details);

            return Task.FromResult(
                ShippingOrderViewModel.ToViewModel(shippingOrder)
            ); ;
        }
    }
}

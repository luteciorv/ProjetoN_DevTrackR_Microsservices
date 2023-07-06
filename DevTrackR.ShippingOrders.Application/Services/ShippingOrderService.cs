using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.Services.Interfaces;
using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.Repositories;
using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Application.Services
{
    public class ShippingOrderService : IShippingOrderService
    {
        private readonly IShippingOrderRepository _repository;

        public ShippingOrderService(IShippingOrderRepository shippingOrderRepository)
        {
            _repository = shippingOrderRepository;
        }

        public async Task<string> AddAsync(AddShippingOrderInputModel inputModel)
        {
            var shippingOrder = inputModel.ToEntity();
            var shippingServices = inputModel.Services.Select(serviceInputModel => serviceInputModel.ToEntity()).ToList();
            
            shippingOrder.AddServices(shippingServices);
            await _repository.AddAsync(shippingOrder);

            return shippingOrder.TrackingCode;
        }

        public async Task<ShippingOrderViewModel> GetByTrackingCodeAsync(string trackingCode)
        {
            var shippingOrder = await _repository.GetByTrackingCodeAsync(trackingCode);
            return ShippingOrderViewModel.ToViewModel(shippingOrder);
        }
    }
}

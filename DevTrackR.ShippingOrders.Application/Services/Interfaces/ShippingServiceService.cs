using DevTrackR.ShippingOrders.Application.ViewModels;
using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Application.Services.Interfaces
{
    public class ShippingServiceService : IShippingService
    {
        public Task<List<ShippingServiceViewModel>> GetAllAsync()
        {
            var shippingServices = new List<ShippingService>()
            {
                new("Selo", 0, 1.2m),
                new("Envio com Registro", 2.2m, 5),
                new("Envio sem registro", 1m, 3)
            };

            return Task.FromResult(
                shippingServices.Select(service => ShippingServiceViewModel.ToViewModel(service)).ToList()
            );
        }
    }
}

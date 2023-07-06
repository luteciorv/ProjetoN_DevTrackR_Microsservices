using DevTrackR.ShippingOrders.Application.InputModels;
using DevTrackR.ShippingOrders.Application.ViewModels;

namespace DevTrackR.ShippingOrders.Application.Services.Interfaces
{
    public interface IShippingOrderService
    {
        string Add(AddShippingOrderInputModel inputModel);
        Task<ShippingOrderViewModel> GetByTrackingCodeAsync(string trackingCode);  
    }
}

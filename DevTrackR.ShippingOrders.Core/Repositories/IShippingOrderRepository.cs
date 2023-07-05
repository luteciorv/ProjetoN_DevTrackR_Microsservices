using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Core.Repositories
{
    public interface IShippingOrderRepository
    {
        Task<ShippingOrder> GetByTrackingCodeAsync(string trackingCode);
        Task AddAsync(ShippingOrder shippingOrder);
    }
}

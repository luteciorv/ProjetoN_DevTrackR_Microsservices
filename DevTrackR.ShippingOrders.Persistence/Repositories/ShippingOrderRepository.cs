using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.Repositories;
using MongoDB.Driver;

namespace DevTrackR.ShippingOrders.Persistence.Repositories
{
    public class ShippingOrderRepository : IShippingOrderRepository
    {
        private readonly IMongoCollection<ShippingOrder> _collection;

        public ShippingOrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrder>("shipping-orders");
        }

        public async Task AddAsync(ShippingOrder shippingOrder) =>
            await _collection.InsertOneAsync(shippingOrder);

        public async Task<ShippingOrder> GetByTrackingCodeAsync(string trackingCode) =>
            await _collection.Find(c => c.TrackingCode == trackingCode).SingleOrDefaultAsync();
    }
}

using DevTrackR.ShippingOrders.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrackR.ShippingOrders.Persistence.Context
{
    public class MongoDbSeed
    {
        private readonly IMongoCollection<ShippingService> _collection;

        private List<ShippingService> _shippingService = new()
        {
            new("Envio estadual", 3.75m, 12m),
            new("Envio internacional", 5.25m, 15m),
            new("Caixa Tamanho P", 0, 5m)
        };

        public MongoDbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingService>("shipping-services");
        }

        public void Populate()
        {
            if (_collection.CountDocuments(c => true) == 0)
                _collection.InsertMany(_shippingService);
        }
    }
}

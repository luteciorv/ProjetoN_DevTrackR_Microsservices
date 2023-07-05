using DevTrackR.ShippingOrders.Core.Enums;
using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Core.Entities
{
    public class ShippingOrder : EntityBase
    {
        public ShippingOrder(ShippingOrderDetails details)
        {
            TrackingCode = Guid.NewGuid().ToString().Replace("-", string.Empty)[..10];

            Details = details;

            Status = EShippingOrderStatus.Started;
            Services = new List<ShippingOrderService>();
        }

        public string TrackingCode { get; private set; }
        public ShippingOrderDetails Details { get; private set; }
        public EShippingOrderStatus Status { get; private set; }
        public decimal TotalPrice { get; private set; }

        public List<ShippingOrderService> Services { get; private set; }


        /// <summary>
        /// Calcula o preço total do envio do pedido e adiciona o serviço ao pedido
        /// </summary>
        /// <param name="services"></param>
        public void AddServices(List<ShippingService> services)
        {
            foreach (var service in services)
            {
                decimal servicePrice = service.FixedPrice + (service.PricePerKg * Details.WeightInKg);
                TotalPrice += servicePrice;
                
                var shippingOrderService = new ShippingOrderService(service.Title, servicePrice);
                Services.Add(shippingOrderService); 
            }
        }
    }
}
;
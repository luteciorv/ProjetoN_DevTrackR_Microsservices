using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Application.InputModels
{
    public class ShippingOrderDetailsInputModel
    {
        public string Description { get; set; }
        public decimal WeightInKg { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }

        public ShippingOrderDetails ToValueObject() =>
            new(Description, WeightInKg, DeliveryAddress.ToValueObject());
    }
}

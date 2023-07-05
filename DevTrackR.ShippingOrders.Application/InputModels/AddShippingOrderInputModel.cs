using DevTrackR.ShippingOrders.Core.Entities;

namespace DevTrackR.ShippingOrders.Application.InputModels
{
    public class AddShippingOrderInputModel
    {
        public ShippingOrderDetailsInputModel Details { get; set; }
        public List<ShippingServiceInputModel> Services { get; set; }

        public ShippingOrder ToEntity() =>
            new(Details.ToValueObject());
    }
}

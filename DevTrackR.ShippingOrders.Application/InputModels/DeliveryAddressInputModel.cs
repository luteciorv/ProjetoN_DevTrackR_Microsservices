using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Application.InputModels
{
    public class DeliveryAddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public DeliveryAddress ToValueObject() =>
            new(Street, Number, ZipCode, City, State, Country);
    }
}

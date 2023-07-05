using DevTrackR.ShippingOrders.Core.Entities;
using DevTrackR.ShippingOrders.Core.ValueObjects;

namespace DevTrackR.ShippingOrders.Application.ViewModels
{
    public class ShippingOrderViewModel
    {
        public ShippingOrderViewModel(string trackingCode, ShippingOrderDetails details, string fullAddress)
        {
            TrackingCode = trackingCode;
            Details = details;
            FullAddress = fullAddress;
        }

        public string TrackingCode { get; private set; }
        public ShippingOrderDetails Details { get; private set; }
        public string FullAddress { get; private set; }

        public static ShippingOrderViewModel ToViewModel(ShippingOrder entity)
        {
            var address = entity.Details.DeliveryAddress;

            return new(
                entity.TrackingCode, 
                entity.Details, 
                $"{address.Country}, {address.ZipCode} - {address.City}, {address.State}, {address.Number}"
            );
        }
    }
}

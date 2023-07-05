namespace DevTrackR.ShippingOrders.Core.ValueObjects
{
    public record ShippingOrderDetails(string Description, decimal WeightInKg, DeliveryAddress DeliveryAddress);
}

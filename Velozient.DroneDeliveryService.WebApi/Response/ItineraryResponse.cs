using DroneDeliveryService.Domain;

namespace DroneDeliveryService.WebApi.Response
{
    public class ItineraryResponse
    {
        public ICollection<DroneResponse> Drones { get; set; }
    }

    public class DroneResponse
    {
        public string Name { get; set; }
        public decimal MaxWeight { get; set; }
        public ICollection<TripResponse> Trips { get; set; }
    }

    public class TripResponse
    {
        public int Id { get; set; }
        public ICollection<DeliveryResponse> Deliveries { get; set; }
    }

    public class DeliveryResponse
    {
        public string Location { get; set; }
        public decimal PackageWeight { get; set; }
    }
}

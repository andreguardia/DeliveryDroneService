using DroneDeliveryService.Domain.Extensions;

namespace DroneDeliveryService.Domain
{
    public class Drone
    {
        public Drone(string name, string maxWeight)
        {
            Name = name.RemoveEnclosures();
            MaxWeight = decimal.Parse(maxWeight.RemoveEnclosures());
            Trips = new List<Trip>();
        }

        public string Name { get; set; }
        public decimal MaxWeight { get; set; }
        public ICollection<Trip> Trips { get; set; }

        public void AddDelivery(Delivery delivery)
        {
            var trip = Trips.FirstOrDefault(t => t.AvailableWeight >= delivery.PackageWeight);
            if (trip != null)
                trip.AddDelivery(delivery);
            else
            {
                trip = new Trip(Trips.Count + 1, this);
                trip.AddDelivery(delivery);
                Trips.Add(trip);
            }
        }
    }
}
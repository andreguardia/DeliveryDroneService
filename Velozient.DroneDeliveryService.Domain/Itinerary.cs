using System.Text;

namespace DroneDeliveryService.Domain
{
    public class Itinerary
    {
        public Itinerary()
        {
            Drones = new List<Drone>();
            Deliveries = new List<Delivery>();
        }

        public ICollection<Drone> Drones { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }

        public void AddDrone(Drone drone)
        {
            if (!Drones.Contains(drone))
                Drones.Add(drone);
        }

        public void Arrange()
        {
            foreach (var delivery in Deliveries)
            {
                var drone = Drones.Where(d => d.MaxWeight > delivery.PackageWeight)
                                  .Where(d => d.Trips.Any(t => t.AvailableWeight >= delivery.PackageWeight))
                                  .FirstOrDefault();
                if (drone != null)
                    drone.AddDelivery(delivery);
                else
                {
                    drone = Drones.OrderBy(d => d.Trips.Count).ThenByDescending(d => d.MaxWeight).FirstOrDefault(d => d.MaxWeight > delivery.PackageWeight);
                    if (drone == null)
                        throw new Exception($"There is no available Drone that can hold {delivery.PackageWeight} weight.");

                    drone.AddDelivery(delivery);
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var drone in Drones)
            {
                builder.AppendLine($"[{drone.Name}]");
                
                foreach (var trip in drone.Trips)
                {
                    builder.AppendLine($"Trip #{trip.Id}");
                    builder.AppendLine($"{string.Join(",", trip.Deliveries.Select(d => $"[{d.Location}]").ToArray())}");
                }

                builder.AppendLine();
            }

            return builder.ToString();

        }

        public static Itinerary Parse(string[] contents)
        {
            var itinerary = new Itinerary();

            for (var i = 0; i < contents.Length; i++)
            {
                var parts = contents[i].Split(',');
                
                if (i == 0)
                    for (int j = 0; j < parts.Length; j += 2)
                        itinerary.AddDrone(new Drone(parts[j], parts[j + 1]));
                else
                    itinerary.Deliveries.Add(new Delivery(parts[0], parts[1]));
            }

            itinerary.Arrange();
            return itinerary;
        }
    }
}

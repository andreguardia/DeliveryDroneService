namespace DroneDeliveryService.Domain
{
    public class Trip
    {
        public Trip(int id, Drone drone)
        {
            Id = id;
            Drone = drone;
            Deliveries = new List<Delivery>();
        }

        public int Id { get; set; }
        public Drone Drone { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }

        public decimal ActualWeigth => Deliveries.Sum(d => d.PackageWeight);
        public decimal AvailableWeight => Drone.MaxWeight - ActualWeigth;

        public void AddDelivery(Delivery delivery) => Deliveries.Add(delivery);
    }
}

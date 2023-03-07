using DroneDeliveryService.Domain.Extensions;

namespace DroneDeliveryService.Domain
{
    public class Delivery
    {
        public Delivery(string location, string packageWeight)
        {
            Location = location.RemoveEnclosures();
            PackageWeight = decimal.Parse(packageWeight.RemoveEnclosures());
        }

        public string Location { get; set; }
        public decimal PackageWeight { get; set; }
    }
}

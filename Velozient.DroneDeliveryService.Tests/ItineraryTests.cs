using DroneDeliveryService.Domain;

namespace Velozient.DroneDeliveryService.Tests
{
    public class ItineraryTests
    {
        [Fact]
        public void Arrange()
        {
            var inputPath = $"{Environment.CurrentDirectory}\\Input\\InputSample.txt";
            var itinerary = Itinerary.Parse(File.ReadAllLines(inputPath));
            
            // Assert that all requested deliveries are assigned to the drones
            Assert.True(itinerary.Deliveries.Count == itinerary.Drones.Sum(d => d.Trips.Sum(t => t.Deliveries.Count)));
        }
    }
}
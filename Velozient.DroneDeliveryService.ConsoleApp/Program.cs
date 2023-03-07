using DroneDeliveryService.Domain;

namespace DroneDeliveryService
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var inputPath = args.Length > 0 ? args[0] : $"{Environment.CurrentDirectory}\\Input\\InputSample.txt";
                var itinerary = Itinerary.Parse(File.ReadAllLines(inputPath));

                Console.WriteLine(File.ReadAllText(inputPath));
                Console.WriteLine();
                Console.WriteLine(itinerary.ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has ocurred: {ex.Message}");
            }
        }
    }
}
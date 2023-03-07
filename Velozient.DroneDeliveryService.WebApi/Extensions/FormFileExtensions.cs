using System.Text;

namespace DroneDeliveryService.WebApi.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<string[]> ReadAsStringAsync(this IFormFile file)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    if (!string.IsNullOrEmpty(line))
                        result.Add(line);
                }
            }
            return result.ToArray();
        }
    }
}

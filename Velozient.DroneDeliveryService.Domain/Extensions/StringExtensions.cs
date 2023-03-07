namespace DroneDeliveryService.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveEnclosures(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return text.Replace("[", string.Empty).Replace("]", string.Empty).Trim();
        }
    }
}

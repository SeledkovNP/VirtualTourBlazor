namespace VirtualTourBlazor.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Для удобства отображения
        public string Coordinates => $"{Latitude:F4}, {Longitude:F4}";
    }
}
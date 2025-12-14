namespace VirtualTourBlazor.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guide Guide { get; set; } = new();
        public List<Place> Places { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();

        // Рассчитанные свойства
        public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
        public int TotalReviews => Reviews.Count;
    }
}
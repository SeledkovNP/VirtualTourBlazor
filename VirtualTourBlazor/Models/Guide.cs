namespace VirtualTourBlazor.Models
{
    public class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        // Для отображения
        public string DisplayInfo => $"{Name} ({Email})";
    }
}

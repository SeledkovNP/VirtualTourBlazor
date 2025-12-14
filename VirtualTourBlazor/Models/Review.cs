namespace VirtualTourBlazor.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Для звездочек рейтинга проверка стикера 4
        public string Stars => new string('★', Rating) + new string('☆', 5 - Rating);
    }
}
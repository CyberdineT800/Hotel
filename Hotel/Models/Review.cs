namespace Hotel.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}

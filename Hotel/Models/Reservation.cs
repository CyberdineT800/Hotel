namespace Hotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

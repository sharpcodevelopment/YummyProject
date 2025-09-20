namespace YummyProject.API.Entities.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string SpecialRequests { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

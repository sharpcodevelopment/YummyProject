namespace YummyProject.API.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string SpecialRequests { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

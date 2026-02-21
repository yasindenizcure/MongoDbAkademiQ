namespace AkademiQMongoDb.DTOs.BookingDtos
{
    public class UpdateBookingDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public bool IsApproved { get; set; }
    }
}

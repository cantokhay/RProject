using Project.Data.Enums;

namespace Project.DTO.BookingDTO
{
    public class ResultBookingDTO
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public int PersonCount { get; set; }

    }
}

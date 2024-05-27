using Project.Data.Enums;

namespace ProjectWebUI.VMs.BookingVM
{
    public class CreateBookingVM
    {
        public string BookingName { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public int PersonCount { get; set; }
    }
}

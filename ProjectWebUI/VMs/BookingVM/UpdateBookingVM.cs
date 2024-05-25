namespace ProjectWebUI.VMs.BookingVM
{
    public class UpdateBookingVM
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public string BookingStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PersonCount { get; set; }
	}
}

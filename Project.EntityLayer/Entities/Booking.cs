using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
    public class Booking : IGenericEntity
    {
        public int BookingId { get; set; }
        public string BookingName { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime BookingDate { get; set; }
        public int PersonCount { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}

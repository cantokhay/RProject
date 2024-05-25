using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
    public class Contact : IGenericEntity
    {
        public int ContactId { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string FooterDescription { get; set; }
        public string FooterTitle { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}
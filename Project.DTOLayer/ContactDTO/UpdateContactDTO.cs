namespace Project.DTO.ContactDTO
{
    public class UpdateContactDTO
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
	}
}

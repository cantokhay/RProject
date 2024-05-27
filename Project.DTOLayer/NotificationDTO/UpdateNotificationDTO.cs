using Project.Data.Enums;

namespace Project.DTO.NotificationDTO
{
    public class UpdateNotificationDTO
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Message { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
	}
}

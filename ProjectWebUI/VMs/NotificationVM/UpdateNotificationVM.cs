using Project.Data.Enums;

namespace ProjectWebUI.VMs.NotificationVM
{
    public class UpdateNotificationVM
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

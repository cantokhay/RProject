namespace ProjectWebUI.VMs.NotificationVM
{
    public class ResultNotificationVM
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Message { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
    }
}

namespace ProjectWebUI.VMs.MessageVM
{
    public class CreateMessageVM
    {
        public string MessageFullName { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public string MessagePhone { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}

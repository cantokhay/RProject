﻿namespace Project.DTO.MessageDTO
{
    public class UpdateMessageDTO
    {
        public int MessageId { get; set; }
        public string MessageFullName { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public string MessagePhone { get; set; }
        public DateTime MessageDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool MessageStatus { get; set; }
	}
}

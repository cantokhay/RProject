using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO.NotificationDTO
{
    public class UpdateNotificationDTO
    {
        public int NotificationId { get; set; }

		[Required(ErrorMessage = "Tür alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Tür en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Type")]
		public string Type { get; set; }

		[Required(ErrorMessage = "İkon alanı zorunludur")]
		[StringLength(50, ErrorMessage = "İkon en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Icon")]
		public string Icon { get; set; }

		[Required(ErrorMessage = "Mesaj alanı zorunludur")]
		[StringLength(250, ErrorMessage = "Mesaj en fazla 250 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Message")]
		public string Message { get; set; }

		[Required(ErrorMessage = "Bildirim Tarihi alanı zorunludur")]
		[Display(Name = "Date")]
		public DateTime NotificationDate { get; set; }

		[Display(Name = "Notification Status")]
		public NotificationStatus NotificationStatus { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

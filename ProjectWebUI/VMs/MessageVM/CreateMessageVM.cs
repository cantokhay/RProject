using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.MessageVM
{
    public class CreateMessageVM
    {
		[Required(ErrorMessage = "Adı Soyadı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Adı Soyadı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Full Name")]
		public string MessageFullName { get; set; }

		[Required(ErrorMessage = "E-posta alanı zorunludur")]
		[EmailAddress(ErrorMessage = "Geçersiz E-posta adresi")]
		[Display(Name = "Email")]
		public string MessageEmail { get; set; }

		[Required(ErrorMessage = "Konu alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Konu en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Subject")]
		public string MessageSubject { get; set; }

		[Required(ErrorMessage = "İçerik alanı zorunludur")]
		[StringLength(500, ErrorMessage = "İçerik en fazla 500 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Content")]
		public string MessageContent { get; set; }

		[Required(ErrorMessage = "Telefon alanı zorunludur")]
		[RegularExpression(@"^(05\d{9})$", ErrorMessage = "Geçersiz telefon numarası")]
		[Display(Name = "Phone")]
		public string MessagePhone { get; set; }

		[Required(ErrorMessage = "Mesaj Tarihi alanı zorunludur")]
		[Display(Name = "Date")]
		public DateTime MessageDate { get; set; }

		[Display(Name = "Message Status")]
		public bool MessageStatus { get; set; }
	}
}

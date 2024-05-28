using System.ComponentModel.DataAnnotations;

namespace Project.DTO.ContactDTO
{
    public class GetContactDTO
    {
        public int ContactId { get; set; }

		[Required(ErrorMessage = "Konum alanı zorunludur")]
		[StringLength(250, ErrorMessage = "Konum en fazla 250 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Location")]
		public string ContactLocation { get; set; }

		[Required(ErrorMessage = "Telefon numarası alanı zorunludur")]
		[Display(Name = "Phone")]
		[RegularExpression(@"^(05(\d{9}))$", ErrorMessage = "Geçersiz telefon numarası")]
		public string ContactPhone { get; set; }

		[Required(ErrorMessage = "E-posta alanı zorunludur")]
		[Display(Name = "Email")]
		[EmailAddress(ErrorMessage = "Geçersiz E-posta adresi")]
		public string ContactEmail { get; set; }

		[Required(ErrorMessage = "Alt Başlıl alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Alt Başlık en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Footer Title")]
		public string FooterTitle { get; set; }

		[Required(ErrorMessage = "Alt başlık açıklama alanı zorunludur")]
		[StringLength(250, ErrorMessage = "Alt başlık açıklama en fazla 250 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Footer Description")]
		public string FooterDescription { get; set; }

		[Required(ErrorMessage = "Açık günler alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Açık günler en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Open Days")]
		public string OpenDays { get; set; }

		[Required(ErrorMessage = "Açık günler açıklama alanı zorunludur")]
		[StringLength(250, ErrorMessage = "Açık günler açıklama en fazla 250 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Open Days Description")]
		public string OpenDaysDescription { get; set; }

		[Required(ErrorMessage = "Açık saatler alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Açık saatler en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Open Hours")]
		public string OpenHours { get; set; }

	}
}

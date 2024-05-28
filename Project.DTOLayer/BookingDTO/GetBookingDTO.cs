using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO.BookingDTO
{
    public class GetBookingDTO
    {
        public int BookingId { get; set; }

		[Required(ErrorMessage = "Rezervasyon İsmi alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Rezervasyon İsmi en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string BookingName { get; set; }

		[Required(ErrorMessage = "Rezervasyon E-posta alanı zorunludur")]
		[EmailAddress(ErrorMessage = "Geçersiz E-posta adresi")]
		[Display(Name = "Email")]
		public string BookingEmail { get; set; }

		[Required(ErrorMessage = "Rezervasyon Telefonu alanı zorunludur")]
		[Phone(ErrorMessage = "Geçersiz telefon numarası")]
		[Display(Name = "Phone")]
		public string BookingPhone { get; set; }

		[Required(ErrorMessage = "Rezervasyon Durumu alanı zorunludur")]
		[Display(Name = "Booking Status")]
		public BookingStatus BookingStatus { get; set; }

		[Required(ErrorMessage = "Rezervasyon Tarihi alanı zorunludur")]
		[Display(Name = "Date")]
		public DateTime BookingDate { get; set; }

		[Required(ErrorMessage = "Kişi Sayısı alanı zorunludur")]
		[Range(1, 9, ErrorMessage = "Kişi Sayısı 1den büyük 9dan küçük olmalıdır")]
		[Display(Name = "Person Count")]
		public int PersonCount { get; set; }
	}
}

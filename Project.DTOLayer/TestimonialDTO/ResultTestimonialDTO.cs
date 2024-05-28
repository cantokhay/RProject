using System.ComponentModel.DataAnnotations;

namespace Project.DTO.TestimonialDTO
{
    public class ResultTestimonialDTO
    {
        public int TestimonialId { get; set; }

		[Required(ErrorMessage = "Yorum alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Yorum en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Comment")]
		public string Comment { get; set; }

		[Required(ErrorMessage = "İsim alanı zorunludur")]
		[StringLength(50, ErrorMessage = "İsim en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string TestimonialName { get; set; }

		[Required(ErrorMessage = "Ünvan alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Ünvan en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title")]
		public string TestimonialTitle { get; set; }

		[Required(ErrorMessage = "Resim URL'si alanı zorunludur")]
		[RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*$", ErrorMessage = "Geçersiz URL formatı")]
		[Display(Name = "Image URL")]
		public string TestimonialImageURL { get; set; }
	}
}

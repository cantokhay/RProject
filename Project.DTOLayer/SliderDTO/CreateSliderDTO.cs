using System.ComponentModel.DataAnnotations;

namespace Project.DTO.SliderDTO
{
	public class CreateSliderDTO
	{
		[Required(ErrorMessage = "Slider Başlığı 1 alanı zorunludur")]
		[StringLength(30, ErrorMessage = "Slider Başlığı 1 en fazla 30 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title 1")]
		public string SliderTitle1 { get; set; }

		[Required(ErrorMessage = "Slider Açıklaması 1 alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Slider Açıklaması 1 en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Description 1")]
		public string SliderDescription1 { get; set; }

		[Required(ErrorMessage = "Slider Başlığı 2 alanı zorunludur")]
		[StringLength(30, ErrorMessage = "Slider Başlığı 2 en fazla 30 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title 2")]
		public string SliderTitle2 { get; set; }

		[Required(ErrorMessage = "Slider Açıklaması 2 alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Slider Açıklaması 2 en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Description 2")]
		public string SliderDescription2 { get; set; }

		[Required(ErrorMessage = "Slider Başlığı 3 alanı zorunludur")]
		[StringLength(30, ErrorMessage = "Slider Başlığı 3 en fazla 30 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title 3")]
		public string SliderTitle3 { get; set; }

		[Required(ErrorMessage = "Slider Açıklaması 3 alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Slider Açıklaması 3 en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Description 3")]
		public string SliderDescription3 { get; set; }
	}
}

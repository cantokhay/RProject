using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.SocialMediaVM
{
    public class UpdateSocialMediaVM
    {
        public int SocialMediaId { get; set; }

		[Required(ErrorMessage = "Sosyal Medya Başlığı alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Sosyal Medya Başlığı en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title")]
		public string SocialMediaTitle { get; set; }

		[Required(ErrorMessage = "Sosyal Medya URL'si alanı zorunludur")]
		[RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", ErrorMessage = "Görsel weblink olmalıdır (örn. https://)")]
		[Display(Name = "URL")]
		public string SocialMediaURL { get; set; }

		[Required(ErrorMessage = "Sosyal Medya İkonu alanı zorunludur")]
		[Display(Name = "Icon")]
		public string SocialMediaIcon { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

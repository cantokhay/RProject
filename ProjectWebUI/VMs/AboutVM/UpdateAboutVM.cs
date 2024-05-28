using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.AboutVM
{
    public class UpdateAboutVM
    {
        public int AboutId { get; set; }

		[Required(ErrorMessage = "Başlık alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title")]
		public string AboutTitle { get; set; }

		[Required(ErrorMessage = "Açıklama alanı zorunludur")]
		[StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Description")]
		public string AboutDescription { get; set; }

		[Required(ErrorMessage = "Görselin web linkini giriniz")]
		[RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", ErrorMessage = "Görsel weblink olmalıdır (örn. https://)")]
		[Display(Name = "Image URL")]
		public string AboutImageURL { get; set; }
		public DateTime CreatedDate { get; set; }
    }
}

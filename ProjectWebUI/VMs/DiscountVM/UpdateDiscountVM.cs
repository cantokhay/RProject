using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.DiscountVM
{
    public class UpdateDiscountVM
    {
        public int DiscountId { get; set; }

		[Required(ErrorMessage = "Başlık alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Title")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Açıklama alanı zorunludur")]
		[StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Description")]
		public string Description { get; set; }

		[Required(ErrorMessage = "İndirim Miktarı alanı zorunludur")]
		[Display(Name = "Amount")]
		public decimal DiscountAmount { get; set; }

		[Required(ErrorMessage = "Resim URL alanı zorunludur")]
		[RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", ErrorMessage = "Görsel weblink olmalıdır (örn. https://)")]
		[Display(Name = "Image URL")]
		public string ImageURL { get; set; }

		[Display(Name = "Discount Status")]
		public bool DiscountStatus { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}

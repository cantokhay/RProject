using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO.ProductDTO
{
	public class ResultProductWithCategoryDTO
	{
		public int ProductId { get; set; }

		[Required(ErrorMessage = "Ürün Adı alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Ürün Adı en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string ProductName { get; set; }

		[Required(ErrorMessage = "Ürün Açıklaması alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Ürün Açıklaması en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Description")]
		public string ProductDescription { get; set; }

		[Required(ErrorMessage = "Ürün Fiyatı alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Ürün Fiyatı virgülden sonra en fazla 2 basamak içerebilir")]
		[Display(Name = "Price")]
		public decimal ProductPrice { get; set; }

		[Required(ErrorMessage = "Ürün Resim URL'si alanı zorunludur")]
		[RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", ErrorMessage = "Görsel weblink olmalıdır (örn. https://)")]
		[Display(Name = "Image URL")]
		public string ProductImageURL { get; set; }

		[Required(ErrorMessage = "Kategori Adı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Kategori Adı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Category Name")]
		public string CategoryName { get; set; }
		public DateTime CreatedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}

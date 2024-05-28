using System.ComponentModel.DataAnnotations;

namespace Project.DTO.BasketDTO
{
    public class ResultBasketDTO
    {
        public int BasketId { get; set; }

		[Required(ErrorMessage = "Fiyat alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Geçersiz fiyat formatı")]
		[Display(Name = "Price")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Miktar alanı zorunludur")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Geçersiz miktar formatı")]
		[Display(Name = "Count")]
		public int Count { get; set; }

		[Required(ErrorMessage = "Toplam Ürün Fiyatı alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Geçersiz toplam ürün fiyatı formatı")]
		[Display(Name = "Total Product Price")]
		public decimal TotalProductPrice { get; set; }

		public int ProductId { get; set; }

        public int CustomerId { get; set; }
    }
}

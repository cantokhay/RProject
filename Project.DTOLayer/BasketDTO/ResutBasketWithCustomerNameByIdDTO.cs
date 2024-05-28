using System.ComponentModel.DataAnnotations;

namespace Project.DTO.BasketDTO
{
    public class ResutBasketWithCustomerNameByIdDTO
    {
		[Required(ErrorMessage = "Müşteri adı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Müşteri adı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Customer Name")]
		public string CustomerName { get; set; }
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

		[Required(ErrorMessage = "Ürün Fiyatı alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Ürün Fiyatı virgülden sonra en fazla 2 basamak içerebilir")]
		[Display(Name = "Price")]
		public decimal ProductPrice { get; set; }

		[Required(ErrorMessage = "Ürün Adı alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Ürün Adı en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string ProductName { get; set; }

		public int CustomerId { get; set; }
    }
}

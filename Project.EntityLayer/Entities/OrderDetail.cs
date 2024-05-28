using Project.Data.Entities.Abstract;
using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Data.Entities
{
	public class OrderDetail : IGenericEntity
	{
		public int OrderDetailId { get; set; }

		[Required(ErrorMessage = "Miktar alanı zorunludur")]
		[Range(1, 9, ErrorMessage = "Miktar en az 1, en fazla 9 olmalıdır")]
		[Display(Name = "Quantity")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Birim Fiyat alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Birim Fiyat virgülden sonra en fazla 2 basamak içerebilir")]
		[Display(Name = "Unit Price")]
		public decimal UnitPrice { get; set; }

		[Required(ErrorMessage = "Toplam Fiyat alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Toplam Fiyat virgülden sonra en fazla 2 basamak içerebilir")]
		[Display(Name = "Total Price")]
		public decimal TotalPrice { get; set; }

		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; }
	}
}

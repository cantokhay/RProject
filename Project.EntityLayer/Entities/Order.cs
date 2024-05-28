using Project.Data.Entities.Abstract;
using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Entities
{
	public class Order : IGenericEntity
	{
        public int OrderId { get; set; }

		[Required(ErrorMessage = "Müşteri Adı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Müşteri Adı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Customer Name")]
		public string CustomerName { get; set; }

		[Required(ErrorMessage = "Sipariş Açıklaması alanı zorunludur")]
		[Display(Name = "Description")]
		public OrderDescription OrderDescription { get; set; }

		[Required(ErrorMessage = "Sipariş Tarihi alanı zorunludur")]
		[Display(Name = "Date")]
		[Column(TypeName = "Date")]
		public DateTime OrderDate { get; set; }

		[Required(ErrorMessage = "Toplam Fiyat alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Toplam Fiyat virgülden sonra en fazla 2 basamak içerebilir")]
		[Display(Name = "Total Price")]
		public decimal TotalPrice { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; }
	}
}

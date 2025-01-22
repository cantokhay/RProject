using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO.CustomerDTO
{
	public class UpdateCustomerDTO
	{
		public int CustomerId { get; set; }

		[Required(ErrorMessage = "Müşteri adı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Müşteri adı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string CustomerName { get; set; }

		[Display(Name = "Customer Status")]
		public CustomerStatus CustomerStatus { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}

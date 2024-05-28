using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.CustomerVM
{
	public class UpdateCustomerVM
	{
		public int CustomerId { get; set; }

		[Required(ErrorMessage = "Müşteri adı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Müşteri adı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string CustomerName { get; set; }
		public DateTime CreatedDate { get; set; }
		public CustomerStatus CustomerStatus { get; set; }
	}
}

using Project.Data.Enums;

namespace Project.DTO.Customer
{
	public class GetCustomerDTO
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public CustomerStatus CustomerStatus { get; set; }
	}
}

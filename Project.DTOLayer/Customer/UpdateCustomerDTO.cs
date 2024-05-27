using Project.Data.Enums;

namespace Project.DTO.Customer
{
	public class UpdateCustomerDTO
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
		public CustomerStatus CustomerStatus { get; set; }
	}
}

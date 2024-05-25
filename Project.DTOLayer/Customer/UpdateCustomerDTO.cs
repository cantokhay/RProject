namespace Project.DTO.Customer
{
	public class UpdateCustomerDTO
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
		public bool CustomerStatus { get; set; }
	}
}

using Project.Data.Enums;

namespace ProjectWebUI.VMs.CustomerVM
{
	public class UpdateCustomerVM
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
		public CustomerStatus CustomerStatus { get; set; }
	}
}

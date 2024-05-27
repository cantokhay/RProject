using Project.Data.Enums;

namespace ProjectWebUI.VMs.CustomerVM
{
	public class ResultCustomerVM
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public CustomerStatus CustomerStatus { get; set; }
	}
}

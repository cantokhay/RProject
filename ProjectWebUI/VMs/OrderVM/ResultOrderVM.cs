using Project.Data.Entities;
using Project.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWebUI.VMs.OrderVM
{
	public class ResultOrderVM
	{
		public int OrderId { get; set; }
		public string CustomerName { get; set; }
		public OrderDescription OrderDescription { get; set; }

		[Column(TypeName = "Date")]
		public DateTime OrderDate { get; set; }

		public decimal TotalPrice { get; set; }
	}
}

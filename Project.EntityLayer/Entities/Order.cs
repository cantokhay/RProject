using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Entities
{
	public class Order
	{
        public int OrderId { get; set; }
		public string CustomerName { get; set; }
        public string OrderDescription { get; set; }

        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}

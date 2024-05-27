using Project.Data.Entities.Abstract;
using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Entities
{
	public class Order : IGenericEntity
	{
        public int OrderId { get; set; }
		public string CustomerName { get; set; }
        public OrderDescription OrderDescription { get; set; }

        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}

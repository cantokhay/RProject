using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
	public class OrderDetail : IGenericEntity
	{
		public int OrderDetailId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		//public decimal Discount { get; set; }
		public decimal TotalPrice { get; set; }
		
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}

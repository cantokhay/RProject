namespace Project.Data.Entities
{
	public class OrderDetail
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
	}
}

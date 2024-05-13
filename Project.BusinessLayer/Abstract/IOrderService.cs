using Project.Data.Entities;

namespace Project.Business.Abstract
{
	public interface IOrderService : IGenericService<Order>
	{
		int TTotalOrderCount();
		public int TActiveOrderCount();
		public decimal TLastOrderPrice();
	}
}

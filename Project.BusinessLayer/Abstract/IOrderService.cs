using Project.Data.Entities;

namespace Project.Business.Abstract
{
	public interface IOrderService : IGenericService<Order>
	{
		int TTotalOrderCount();
		int TActiveOrderCount();
		decimal TLastOrderPrice();
		decimal TGetTodayTotalPrice();
		void TOrderPaid(int orderId);
		void TOrderTaken(int orderId);

	}
}

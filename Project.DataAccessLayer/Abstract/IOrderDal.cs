using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
	public interface IOrderDal : IGenericDal<Order>
	{
		int TotalOrderCount();
		int ActiveOrderCount();
		decimal LastOrderPrice();
		decimal GetTodayTotalPrice();
	}
}

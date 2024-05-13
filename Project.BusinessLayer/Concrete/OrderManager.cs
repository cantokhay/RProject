using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int TActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();

		}

		public void TAdd(Order entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public List<Order> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Order TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public decimal TLastOrderPrice()
		{
			return _orderDal.LastOrderPrice();
		}

		public int TTotalOrderCount()
		{
			return _orderDal.TotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}

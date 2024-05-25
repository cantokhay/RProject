using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
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
			_orderDal.Add(entity);
		}

		public void TDelete(Order entity)
		{
			entity.DataStatus = DataStatus.Deleted;
			entity.DeletedDate = DateTime.Now;
			_orderDal.Delete(entity);
		}

		public List<Order> TGetAll()
		{
			return _orderDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

		public Order TGetById(int id)
		{
			return _orderDal.GetById(id);
		}

		public decimal TGetTodayTotalPrice()
		{
			return _orderDal.GetTodayTotalPrice();
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
			_orderDal.Update(entity);
		}
	}
}

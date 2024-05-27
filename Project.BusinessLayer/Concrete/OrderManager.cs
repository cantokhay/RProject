using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;
using Project.DataAccess.EF;

namespace Project.Business.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;
		private readonly IMoneyCaseDal _moneyCaseDal;

		public OrderManager(IOrderDal orderDal, IMoneyCaseDal moneyCaseDal)
		{
			_orderDal = orderDal;
			_moneyCaseDal = moneyCaseDal;
		}

		public void TOrderPaid(int orderId)
		{
			_orderDal.OrderPaid(orderId);
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
			var existingOrder = _orderDal.GetById(entity.OrderId);
			if (existingOrder != null && existingOrder.OrderDescription != entity.OrderDescription && entity.OrderDescription == OrderDescription.OrderPaid)
			{
				var moneyCase = _moneyCaseDal.GetAll().FirstOrDefault();

				if (moneyCase != null)
				{
					moneyCase.TotalMoneyInCase += entity.TotalPrice;
					_moneyCaseDal.Update(moneyCase);
				}
			}
			_orderDal.Update(entity);
		}

		public void TOrderTaken(int orderId)
		{
			_orderDal.OrderTaken(orderId);
		}
	}
}

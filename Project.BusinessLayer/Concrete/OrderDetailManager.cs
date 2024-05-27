using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;
		private readonly IOrderDal _orderDal;

		public OrderDetailManager(IOrderDetailDal orderDetailDal, IOrderDal orderDal)
		{
			_orderDetailDal = orderDetailDal;
			_orderDal = orderDal;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);

			var order = _orderDal.GetById(entity.OrderId);

			if (order != null)
			{
				order.TotalPrice += entity.TotalPrice;
				_orderDal.Update(order);
			}
		}

		public void TDelete(OrderDetail entity)
		{
			entity.DataStatus = DataStatus.Deleted;
			entity.DeletedDate = DateTime.Now;
			_orderDetailDal.Delete(entity);

			var order = _orderDal.GetById(entity.OrderId);

			if (order != null)
			{
				order.TotalPrice -= entity.TotalPrice;
				_orderDal.Update(order);
			}
		}

		public List<OrderDetail> TGetAll()
		{
			return _orderDetailDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

		public OrderDetail TGetById(int id)
		{
			return _orderDetailDal.GetById(id);
		}

		public void TUpdate(OrderDetail entity)
		{
			_orderDetailDal.Update(entity);
		}
	}
}

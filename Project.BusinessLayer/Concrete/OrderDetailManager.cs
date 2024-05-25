using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

		public void TAdd(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);
		}

		public void TDelete(OrderDetail entity)
		{
			entity.DataStatus = DataStatus.Deleted;
			entity.DeletedDate = DateTime.Now;
			_orderDetailDal.Delete(entity);
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

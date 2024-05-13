using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

		public void TAdd(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(OrderDetail entity)
		{
			throw new NotImplementedException();
		}

		public List<OrderDetail> TGetAll()
		{
			throw new NotImplementedException();
		}

		public OrderDetail TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(OrderDetail entity)
		{
			throw new NotImplementedException();
		}
	}
}

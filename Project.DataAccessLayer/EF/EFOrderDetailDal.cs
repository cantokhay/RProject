using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
	public class EFOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
	{
		public EFOrderDetailDal(SignalRContext context) : base(context)
		{
		}
	}
}

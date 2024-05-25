using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
	public class EFCustomerDal : GenericRepository<Customer>, ICustomerDal
	{
		public EFCustomerDal(SignalRContext context) : base(context)
		{
		}

		public int CustomerCount()
		{
			using var _context = new SignalRContext();
			return _context.Customers.Where(c => c.DataStatus != DataStatus.Deleted).Count();
		}
	}
}

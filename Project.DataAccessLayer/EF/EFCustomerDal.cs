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

        public void ChangeCustomerStatusToHasNotOrder(int customerId)
        {
            using var _context = new SignalRContext();
			var customer = _context.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
			customer.CustomerStatus = CustomerStatus.HasNotOrder;
            _context.SaveChanges();
        }

        public void ChangeCustomerStatusToHasOrder(int customerId)
        {
            using var _context = new SignalRContext();
            var customer = _context.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            customer.CustomerStatus = CustomerStatus.HasOrder;
            _context.SaveChanges();
        }

        public int CustomerCount()
		{
			using var _context = new SignalRContext();
			return _context.Customers.Where(c => c.DataStatus != DataStatus.Deleted && c.CustomerStatus == CustomerStatus.HasOrder).Count();
		}
	}
}

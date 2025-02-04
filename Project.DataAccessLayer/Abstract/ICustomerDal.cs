using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
	public interface ICustomerDal : IGenericDal<Customer>
	{
		int CustomerCount();
		void ChangeCustomerStatusToHasOrder(int customerId);
		void ChangeCustomerStatusToHasNotOrder(int customerId);
	}
}

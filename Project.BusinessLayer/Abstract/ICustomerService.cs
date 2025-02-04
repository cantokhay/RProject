using Project.Data.Entities;

namespace Project.Business.Abstract
{
	public interface ICustomerService : IGenericService<Customer>
	{
		int TCustomerCount();
        void TChangeCustomerStatusToHasOrder(int customerId);
        void TChangeCustomerStatusToHasNotOrder(int customerId);
    }
}

using Project.Data.Entities;

namespace Project.Business.Abstract
{
	public interface ICustomerService : IGenericService<Customer>
	{
		public int TCustomerCount();
	}
}

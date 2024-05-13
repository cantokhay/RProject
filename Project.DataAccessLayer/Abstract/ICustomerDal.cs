using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
	public interface ICustomerDal : IGenericDal<Customer>
	{
		int CustomerCount();
	}
}

using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		private readonly ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		public void TAdd(Customer entity)
		{
			throw new NotImplementedException();
		}

		public int TCustomerCount()
		{
			var customerCount = _customerDal.CustomerCount();
			return customerCount;
		}

		public void TDelete(Customer entity)
		{
			throw new NotImplementedException();
		}

		public List<Customer> TGetAll()
		{
			throw new NotImplementedException();
		}

		public Customer TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Customer entity)
		{
			throw new NotImplementedException();
		}
	}
}

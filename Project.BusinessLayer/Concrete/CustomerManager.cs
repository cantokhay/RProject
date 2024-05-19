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
			_customerDal.Add(entity);
		}

		public int TCustomerCount()
		{
			var customerCount = _customerDal.CustomerCount();
			return customerCount;
		}

		public void TDelete(Customer entity)
		{
			_customerDal.Delete(entity);
		}

		public List<Customer> TGetAll()
		{
			return _customerDal.GetAll();
		}

		public Customer TGetById(int id)
		{
			return _customerDal.GetById(id);
		}

		public void TUpdate(Customer entity)
		{
			_customerDal.Update(entity);
		}
	}
}

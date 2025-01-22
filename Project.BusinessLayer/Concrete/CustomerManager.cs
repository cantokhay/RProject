using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
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
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Active;
			entity.CustomerStatus = CustomerStatus.HasNotOrder;
            _customerDal.Add(entity);
		}

		public int TCustomerCount()
		{
			var customerCount = _customerDal.CustomerCount();
			return customerCount;
		}

		public void TDelete(Customer entity)
		{
			entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_customerDal.Delete(entity);
		}

		public List<Customer> TGetAll()
		{
			return _customerDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

		public Customer TGetById(int id)
		{
			return _customerDal.GetById(id);
		}

		public void TUpdate(Customer entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Modified;
            _customerDal.Update(entity);
		}
	}
}

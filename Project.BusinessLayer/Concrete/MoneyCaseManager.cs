using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void TAdd(MoneyCase entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Active;
            _moneyCaseDal.Add(entity);
		}

		public void TDelete(MoneyCase entity)
		{
			entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_moneyCaseDal.Delete(entity);
		}

		public List<MoneyCase> TGetAll()
		{
			return _moneyCaseDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

		public MoneyCase TGetById(int id)
		{
			return _moneyCaseDal.GetById(id);
		}

		public decimal TGetTotalMoneyInCase()
		{
			return _moneyCaseDal.GetTotalMoneyInCase();
		}

		public void TUpdate(MoneyCase entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Modified;
            _moneyCaseDal.Update(entity);
		}
	}
}

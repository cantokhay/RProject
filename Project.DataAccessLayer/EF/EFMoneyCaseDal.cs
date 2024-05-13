using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
	public class EFMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EFMoneyCaseDal(SignalRContext context) : base(context)
		{
		}

		public decimal GetTotalMoneyInCase()
		{
			using var context = new SignalRContext();
			return context.MoneyCases.Select(x => x.TotalMoneyInCase).FirstOrDefault();
		}
	}
}

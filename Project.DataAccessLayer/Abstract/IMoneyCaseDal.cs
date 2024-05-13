using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
	public interface IMoneyCaseDal : IGenericDal<MoneyCase>
	{
		decimal GetTotalMoneyInCase();
	}
}

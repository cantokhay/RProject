using Project.Data.Entities;

namespace Project.Business.Abstract
{
	public interface IMoneyCaseService : IGenericService<MoneyCase>
	{
		decimal TGetTotalMoneyInCase();
	}
}

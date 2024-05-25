using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
	public class MoneyCase : IGenericEntity
	{
        public int MoneyCaseId { get; set; }
		public decimal TotalMoneyInCase { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}

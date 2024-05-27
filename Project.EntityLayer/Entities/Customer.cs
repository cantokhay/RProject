using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
	public class Customer : IGenericEntity
	{
        public int CustomerId { get; set; }
		public string CustomerName { get; set; }
        public CustomerStatus CustomerStatus { get; set; }

        public List<Basket> Baskets { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}

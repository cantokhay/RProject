namespace Project.Data.Entities
{
	public class Customer
	{
        public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public bool CustomerStatus { get; set; }

        public List<Basket> Baskets { get; set; }
    }
}

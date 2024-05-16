namespace Project.Data.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalProductPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}

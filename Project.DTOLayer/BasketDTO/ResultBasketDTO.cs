namespace Project.DTO.BasketDTO
{
    public class ResultBasketDTO
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalProductPrice { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }
    }
}

namespace Project.DTO.ProductDTO
{
    public class ResultProductWithCategoryDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public bool ProductStatus { get; set; }
        public string CategoryName { get; set; }
    }
}

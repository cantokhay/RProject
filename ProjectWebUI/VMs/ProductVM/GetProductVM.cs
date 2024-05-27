using Project.Data.Enums;

namespace ProjectWebUI.VMs.ProductVM
{
    public class GetProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public DataStatus DataStatus { get; set; }
        public int CategoryId { get; set; }
    }
}

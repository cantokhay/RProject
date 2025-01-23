using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
		List<Product> GetProductsByCategory();
        int GetProductCount();
        int GetProductCountByCategoryNameHamburger();
        int GetProductCountByCategoryNameDesert();
        decimal ProductPriceAvg();
        string ProductNameByMinPrice();
        string ProductNameByMaxPrice();
        decimal ProductAvgPriceByHamburger();
        decimal TotalProductPriceSum();
        List<Product> GetLast9Products();

    }
}

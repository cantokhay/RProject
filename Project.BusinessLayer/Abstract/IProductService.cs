using Project.Data.Entities;

namespace Project.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsByCategory();
		int TGetProductCount();
		int TGetProductCountByCategoryNameHamburger();
		int TGetProductCountByCategoryNameDesert();
		decimal TProductPriceAvg();
		string TProductNameByMinPrice();
		string TProductNameByMaxPrice();
		decimal TProductAvgPriceByHamburger();
        decimal TTotalProductPriceSum();
		List<Product> TGetLast9Products();
    }
}

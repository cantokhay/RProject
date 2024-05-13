using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

		public int TGetProductCount()
		{
			return _productDal.GetProductCount();
		}

		public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetProductsByCategory()
        {
            return _productDal.GetProductsByCategory();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

		public int TGetProductCountByCategoryNameHamburger()
		{
			return _productDal.GetProductCountByCategoryNameHamburger();
		}

		public int TGetProductCountByCategoryNameDesert()
		{
			return _productDal.GetProductCountByCategoryNameDesert();
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public string TProductNameByMinPrice()
		{
			return _productDal.ProductNameByMinPrice();
		}

		public string TProductNameByMaxPrice()
		{
			return _productDal.ProductNameByMaxPrice();
		}

		public decimal TProductAvgPriceByHamburger()
		{
			return _productDal.ProductAvgPriceByHamburger();
		}
	}
}

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
    }
}

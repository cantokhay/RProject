using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsByCategory();

    }
}

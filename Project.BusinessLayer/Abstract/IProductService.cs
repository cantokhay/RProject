using Project.Data.Entities;

namespace Project.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsByCategory();
    }
}

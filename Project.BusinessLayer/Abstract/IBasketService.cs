using Project.Data.Entities;

namespace Project.Business.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        public List<Basket> TGetBasketByCustomerId(int id);
    }
}

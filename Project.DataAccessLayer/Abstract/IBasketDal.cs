using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByCustomerId(int id);
    }
}

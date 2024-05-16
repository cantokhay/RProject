using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public List<Basket> TGetBasketByCustomerId(int id)
        {
            return _basketDal.GetBasketByCustomerId(id);
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }

    }
}

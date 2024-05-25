using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
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
            return _basketDal.GetBasketByCustomerId(id).Where(x => x.DataStatus != DataStatus.Deleted).ToList();
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
			entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TUpdate(Basket entity)
        {
			_basketDal.Update(entity);
		}

    }
}

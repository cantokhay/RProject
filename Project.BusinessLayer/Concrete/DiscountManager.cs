using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public List<Discount> TGetActiveDiscounts()
        {
            return _discountDal.GetActiveDiscounts();
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TChangeStatusFalse(int id)
        {
            _discountDal.ChangeStatusFalse(id);
        }

        public void TChangeStatusTrue(int id)
        {
            _discountDal.ChangeStatusTrue(id);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> TGetAll()
        {
            return _discountDal.GetAll();
        }

        public Discount TGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}

using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EFDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusFalse(int id)
        {
            using var context = new SignalRContext();
            var discount = context.Discounts.Find(id);
            discount.DiscountStatus = false;
            context.SaveChanges();
        }

        public void ChangeStatusTrue(int id)
        {
            using var context = new SignalRContext();
            var discount = context.Discounts.Find(id);
            discount.DiscountStatus = true;
            context.SaveChanges();
        }

        public List<Discount> GetActiveDiscounts()
        {
            using var context = new SignalRContext();
            var discountList = context.Discounts.Where(x => x.DiscountStatus == true).ToList();
            return discountList;
        }
    }
}

using Project.Data.Entities;
using Project.Data.Enums;
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

        public decimal AvgDiscountRate()
        {
            using var context = new SignalRContext();
            var avgDiscountRate = context.Discounts.Where(x => x.DataStatus != DataStatus.Deleted).Average(x => x.DiscountAmount);
            return avgDiscountRate;
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
            var discountList = context.Discounts.Where(x => x.DiscountStatus == true && x.DataStatus != DataStatus.Deleted).ToList();
            return discountList;
        }
    }
}

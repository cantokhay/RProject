using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        void ChangeStatusFalse(int id);
        void ChangeStatusTrue(int id);
        List<Discount> GetActiveDiscounts();
        decimal AvgDiscountRate();
    }
}

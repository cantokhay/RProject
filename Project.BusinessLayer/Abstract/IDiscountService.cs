using Project.Data.Entities;

namespace Project.Business.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangeStatusFalse(int id);
        void TChangeStatusTrue(int id);
        List<Discount> TGetActiveDiscounts();
    }
}

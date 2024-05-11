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
    }
}

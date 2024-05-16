using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EFBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByCustomerId(int id)
        {
            using var context = new SignalRContext();
            return context.Baskets.Where(x => x.CustomerId == id).Include(y => y.Product).ToList();
        }

    }
}

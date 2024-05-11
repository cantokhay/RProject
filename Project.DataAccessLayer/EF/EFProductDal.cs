using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsByCategory()
        {
            var context = new SignalRContext();
            var products = context.Products.Include(p => p.Category).ToList();
            return products;
        }
    }
}

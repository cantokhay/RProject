using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using Project.Data.Enums;
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

		public int GetProductCount()
		{
			using var context = new SignalRContext();
            return context.Products.Count();
		}

		public int GetProductCountByCategoryNameDesert()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.CategoryId==(context.Categories.Where(c => c.CategoryName == "tatlı" && c.DataStatus != DataStatus.Deleted).Select(x => x.CategoryId).FirstOrDefault())).Count();
		}

		public int GetProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.CategoryId == (context.Categories.Where(c => c.CategoryName == "hamburger" && c.DataStatus != DataStatus.Deleted).Select(x => x.CategoryId).FirstOrDefault())).Count();
		}

		public List<Product> GetProductsByCategory()
        {
            var context = new SignalRContext();
            var products = context.Products.Include(p => p.Category).Where(p => p.DataStatus != DataStatus.Deleted).ToList();
            return products;
        }

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.ProductPrice == context.Products.Max(x => x.ProductPrice) && p.DataStatus != DataStatus.Deleted).Select(x => x.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.ProductPrice == context.Products.Min(x => x.ProductPrice) && p.DataStatus != DataStatus.Deleted).Select(x => x.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();
			return context.Products.Average(p => p.ProductPrice);
		}

		public decimal ProductAvgPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.CategoryId == (context.Categories.Where(c => c.CategoryName == "hamburger" && c.DataStatus != DataStatus.Deleted).Select(x => x.CategoryId).FirstOrDefault()) && p.DataStatus != DataStatus.Deleted).Average(x => x.ProductPrice);
		}
	}
}

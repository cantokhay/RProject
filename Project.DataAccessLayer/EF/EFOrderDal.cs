using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
	public class EFOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EFOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(o => o.OrderDescription == "Sipariş Aktif" && o.DataStatus != DataStatus.Deleted).Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.OrderByDescending(o => o.OrderId).Take(1).Select(o => o.TotalPrice).FirstOrDefault();
		}

		public decimal GetTodayTotalPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(o => o.OrderDate == DateTime.Parse(DateTime.Today.ToShortDateString()) && o.DataStatus != DataStatus.Deleted).Sum(o => o.TotalPrice);
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.DataStatus != DataStatus.Deleted).Count();
		}
	}
}

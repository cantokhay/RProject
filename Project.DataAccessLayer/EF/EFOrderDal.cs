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
			return context.Orders.Where(o => o.OrderDescription == OrderDescription.OrderTaken && o.DataStatus != DataStatus.Deleted).Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.DataStatus != DataStatus.Deleted).ToList().OrderByDescending(o => o.OrderId).Take(1).Select(o => o.TotalPrice).FirstOrDefault();
		}

		public decimal GetTodayTotalPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(o => o.OrderDate.Date == DateTime.Today && o.DataStatus != DataStatus.Deleted).Sum(o => o.TotalPrice);
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.DataStatus != DataStatus.Deleted).Count();
		}

		public void OrderPaid(int orderId)
		{
			using var context = new SignalRContext();
			var order = context.Orders.Find(orderId);
			order.OrderDescription = OrderDescription.OrderPaid;
			context.SaveChanges();
		}

		public void OrderTaken(int orderId)
		{
			using var context = new SignalRContext();
			var order = context.Orders.Find(orderId);
			order.OrderDescription = OrderDescription.OrderTaken;
			context.SaveChanges();
		}
	}
}

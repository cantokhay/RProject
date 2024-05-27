using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public IActionResult GetOrders()
		{
			var orders = _orderService.TGetAll();
			return Ok(orders);
		}

		[HttpGet("TOTAL_ORDER_COUNT")]
		public IActionResult TotalOrderCount()
		{
			var totalOrderCount = _orderService.TTotalOrderCount();
			return Ok(totalOrderCount);
		}

		[HttpGet("ACTIVE_ORDER_COUNT")]
		public IActionResult ActiveOrderCount()
		{
			var activeOrderCount = _orderService.TActiveOrderCount();
			return Ok(activeOrderCount);
		}

		[HttpGet("LAST_ORDER_PRICE")]
		public IActionResult LastOrderPrice()
		{
			var lastOrderPrice = _orderService.TLastOrderPrice();
			return Ok(lastOrderPrice);
		}

		[HttpGet("GET_TODAY_TOTAL_PRICE")]
		public IActionResult GetTodayTotalPrice()
		{
			var todayTotalPrice = _orderService.TGetTodayTotalPrice();
			return Ok(todayTotalPrice);
		}

		[HttpGet("ORDER_PAID/{id}")]
		public IActionResult OrderPaid(int id)
		{
			_orderService.TOrderPaid(id);
			return Ok();
		}

		[HttpGet("ORDER_TAKEN/{id}")]
		public IActionResult OrderTaken(int id)
		{
			_orderService.TOrderTaken(id);
			return Ok();
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet("GET_TOTAL_MONEY_IN_CASE")]
		public IActionResult GetTotalMoneyInCase()
		{
			var totalMoneyInCase = _moneyCaseService.TGetTotalMoneyInCase();
			return Ok(totalMoneyInCase);
		}
	}
}
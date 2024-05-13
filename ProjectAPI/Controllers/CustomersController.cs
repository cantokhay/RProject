using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet("CUSTOMER_COUNT")]
		public IActionResult CustomerCount()
		{
			var customerCount = _customerService.TCustomerCount();
			return Ok(customerCount);
		}
	}
}

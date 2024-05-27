using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.Customer;

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

		[HttpGet]
		public IActionResult CustomerList()
		{
			var customerList = _customerService.TGetAll();
			return Ok(customerList);
		}

		[HttpPost]
		public IActionResult CreateCustomer(CreateCustomerDTO createCustomertDTO)
		{
			_customerService.TAdd(new Customer()
			{
				CustomerName = createCustomertDTO.CustomerName,
				CustomerStatus = CustomerStatus.HasNotOrder,
				CreatedDate = DateTime.Now,
				DataStatus = DataStatus.Active
			});
			return Ok("Müşteri Eklendi!");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCustomer(int id)
		{
			var customer = _customerService.TGetById(id);
			_customerService.TDelete(customer);
			return Ok("Müşteri Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateCustomer(UpdateCustomerDTO updateCustomerDTO)
		{
			_customerService.TUpdate(new Customer()
			{
				CustomerId = updateCustomerDTO.CustomerId,
				CustomerName = updateCustomerDTO.CustomerName,
				CustomerStatus = updateCustomerDTO.CustomerStatus,
				CreatedDate = updateCustomerDTO.CreatedDate,
				DataStatus = DataStatus.Modified,
				ModifiedDate = DateTime.Now
			});
			return Ok("Müşteri Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetCustomerById(int id)
		{
			var customer = _customerService.TGetById(id);
			return Ok(customer);
		}
	}
}

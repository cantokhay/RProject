using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.CustomerDTO;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;
		private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
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
			return Ok(_mapper.Map<List<ResultCustomerDTO>>(customerList));
		}

		[HttpPost]
		public IActionResult CreateCustomer(CreateCustomerDTO createCustomertDTO)
		{
			var customer = _mapper.Map<Customer>(createCustomertDTO);
            _customerService.TAdd(customer);
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
			var customer = _mapper.Map<Customer>(updateCustomerDTO);
            _customerService.TUpdate(customer);
			return Ok("Müşteri Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetCustomerById(int id)
		{
			var customer = _customerService.TGetById(id);
			return Ok(_mapper.Map<GetCustomerDTO>(customer));
		}

		[HttpGet("CHANGE_CUSTOMER_STATUS_TO_HASORDER")]
		public IActionResult ChangeCustomerStatusToHasOrder(int customerId)
        {
            _customerService.TChangeCustomerStatusToHasOrder(customerId);
            return Ok("Müşteri Durumu Siparişi Var Olarak Güncellendi!");
        }

        [HttpGet("CHANGE_CUSTOMER_STATUS_TO_HASNOTORDER")]
        public IActionResult ChangeCustomerStatusToHasNotOrder(int customerId)
        {
            _customerService.TChangeCustomerStatusToHasNotOrder(customerId);
            return Ok("Müşteri Durumu Siparişi Yok Olarak Güncellendi!");
        }
    }
}

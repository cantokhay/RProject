using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Concrete;
using Project.DTO.BasketDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("BASKET_LIST_BY_CUSTOMER_ID")]
		public ActionResult<List<ResutBasketWithCustomerNameByIdDTO>> GetBasketListWithCustomerNameById(int customerId)
		{
			var baskets = _basketService.TGetBasketByCustomerId(customerId);
			return Ok(baskets);
		}

		[HttpPost]
        public IActionResult CreateBasket(CreateBasketDTO createBasketDTO)
        {
            using var context = new SignalRContext();
            var price = context.Products.Where(x => x.ProductId == createBasketDTO.ProductId).Select(x => x.ProductPrice).FirstOrDefault();
            var count = createBasketDTO.Count;
            _basketService.TAdd(new Basket
            {
                Count = count,
                CustomerId = 4,
                ProductId = createBasketDTO.ProductId,
                Price = price,
                TotalProductPrice = price * count,
				CreatedDate = DateTime.Now,
				DataStatus = DataStatus.Active
			});
            return Ok("Ürün Sepetinize Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}

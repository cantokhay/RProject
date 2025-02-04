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

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
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

            var product = context.Products.FirstOrDefault(x => x.ProductId == createBasketDTO.ProductId);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı!");
            }

            var price = product.ProductPrice;

            var existingBasketItem = context.Baskets.FirstOrDefault(b =>
                                 b.ProductId == createBasketDTO.ProductId &&
                                 b.CustomerId == createBasketDTO.CustomerId);

            if (existingBasketItem != null)
            {
                // Eğer ürün zaten sepetteyse miktarı güncelle ve toplam fiyatı yeniden hesapla
                var count = existingBasketItem.Count;
                count++;
                existingBasketItem.Count = count;
                existingBasketItem.TotalProductPrice = existingBasketItem.Price * existingBasketItem.Count;
                existingBasketItem.ModifiedDate = DateTime.Now;
                _basketService.TUpdate(existingBasketItem);
            }
            else
            {
                // Ürün sepette değilse yeni bir ürün ekle
                var newBasket = new Basket
                {
                    Count = 1,
                    CustomerId = createBasketDTO.CustomerId,
                    ProductId = createBasketDTO.ProductId,
                    Price = price,
                    TotalProductPrice = price,
                    CreatedDate = DateTime.Now,
                    DataStatus = DataStatus.Active
                };
                _basketService.TAdd(newBasket);
            }

            return Ok("Ürün Sepetinize başarıyla eklendi!");
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

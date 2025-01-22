using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.DiscountDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var discountList = _discountService.TGetAll();
            return Ok(_mapper.Map<List<ResultDiscountDTO>>(discountList));
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDTO createDiscountDTO)
        {
            var discount = _mapper.Map<Discount>(createDiscountDTO);
            _discountService.TAdd(discount);
            return Ok("İndirim Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var discount = _discountService.TGetById(id);
            _discountService.TDelete(discount);
            return Ok("İndirim Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDTO updateDiscountDTO)
        {
            var discount = _mapper.Map<Discount>(updateDiscountDTO);
            _discountService.TUpdate(discount);
            return Ok("İndirim Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscountById(int id)
        {
            var discount = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDTO>(discount));
        }

        [HttpGet("ACTIVATE_DISCOUNT/{id}")]
        public IActionResult ActivateDiscount(int id)
        {
            _discountService.TChangeStatusTrue(id);
            return Ok("İndirim Aktif Edildi!");
        }

        [HttpGet("PASSIVATE_DISCOUNT/{id}")]
        public IActionResult PassivateDiscount(int id)
        {
            _discountService.TChangeStatusFalse(id);
            return Ok("İndirim Pasif Edildi!");
        }

        [HttpGet("ACTIVE_DISCOUNTS")]
        public IActionResult GetActiveDiscounts()
        {
            var discountList = _discountService.TGetActiveDiscounts();
            return Ok(discountList);
        }
    }
}

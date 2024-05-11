using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
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
            var discountList =_discountService.TGetAll();
            return Ok(discountList);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDTO createDiscountDTO)
        {
            _discountService.TAdd(new Discount()
            {
                Title = createDiscountDTO.Title,
                Description = createDiscountDTO.Description,
                DiscountAmount = createDiscountDTO.DiscountAmount,
                ImageURL = createDiscountDTO.ImageURL
            });
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
            _discountService.TUpdate(new Discount()
            {
                DiscountId = updateDiscountDTO.DiscountId,
                Title = updateDiscountDTO.Title,
                Description = updateDiscountDTO.Description,
                DiscountAmount = updateDiscountDTO.DiscountAmount,
                ImageURL = updateDiscountDTO.ImageURL
            });
            return Ok("İndirim Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscountById(int id)
        {
            var discount = _discountService.TGetById(id);
            return Ok(discount);
        }
    }
}

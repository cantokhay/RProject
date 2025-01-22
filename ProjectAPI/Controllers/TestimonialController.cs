using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.TestimonialDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testimonialList = _testimonialService.TGetAll();
            return Ok(_mapper.Map<List<ResultTestimonialDTO>>(testimonialList));
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDTO);
            _testimonialService.TAdd(testimonial);
            return Ok("Yorum Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            _testimonialService.TDelete(testimonial);
            return Ok("Yorum Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDTO);
            _testimonialService.TUpdate(testimonial);
            return Ok("Yorum Güncellendi!");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDTO>(testimonial));
        }
    }
}

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

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testimonialList = _testimonialService.TGetAll();
            return Ok(testimonialList);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Comment = createTestimonialDTO.Comment,
                TestimonialName = createTestimonialDTO.TestimonialName,
                TestimonialTitle = createTestimonialDTO.TestimonialTitle,
                TestimonialImageURL = createTestimonialDTO.TestimonialImageURL,
                TestimonialStatus = createTestimonialDTO.TestimonialStatus,
                CreatedDate = DateTime.Now,
				DataStatus = DataStatus.Active
			});
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
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialId = updateTestimonialDTO.TestimonialId,
                Comment = updateTestimonialDTO.Comment,
                TestimonialName = updateTestimonialDTO.TestimonialName,
                TestimonialTitle = updateTestimonialDTO.TestimonialTitle,
                TestimonialImageURL = updateTestimonialDTO.TestimonialImageURL,
                TestimonialStatus = updateTestimonialDTO.TestimonialStatus,
				CreatedDate = updateTestimonialDTO.CreatedDate,
				DataStatus = DataStatus.Modified,
				ModifiedDate = DateTime.Now
			});
            return Ok("Yorum Güncellendi!");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(testimonial);
        }
    }
}

using AutoMapper;
using Project.Data.Entities;
using Project.DTO.TestimonialDTO;

namespace ProjectAPI.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDTO>().ReverseMap();
        }
    }
}

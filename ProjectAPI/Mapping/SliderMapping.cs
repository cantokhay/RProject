using AutoMapper;
using Project.Data.Entities;
using Project.DTO.SliderDTO;

namespace ProjectAPI.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<Slider, CreateSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();
            CreateMap<Slider, GetSliderDTO>().ReverseMap();
        }
    }
}

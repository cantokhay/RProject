using AutoMapper;
using Project.Data.Entities;
using Project.DTO.AboutDTO;

namespace ProjectAPI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            CreateMap<About, GetAboutDTO>().ReverseMap();
        }
    }
}

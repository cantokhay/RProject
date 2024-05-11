using AutoMapper;
using Project.Data.Entities;
using Project.DTO.SocialMediaDTO;

namespace ProjectAPI.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDTO>().ReverseMap();
        }
    }
}

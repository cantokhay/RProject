using AutoMapper;
using Project.Data.Entities;
using Project.DTO.FeatureDTO;

namespace ProjectAPI.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetFeatureDTO>().ReverseMap();
        }
    }
}

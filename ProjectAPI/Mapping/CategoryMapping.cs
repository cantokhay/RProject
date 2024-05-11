using AutoMapper;
using Project.Data.Entities;
using Project.DTO.CategoryDTO;

namespace ProjectAPI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
        }
    }
}

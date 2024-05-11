using AutoMapper;
using Project.Data.Entities;
using Project.DTO.ProductDTO;

namespace ProjectAPI.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ReverseMap();
        }
    }
}

using AutoMapper;
using Project.Data.Entities;
using Project.DTO.DiscountDTO;

namespace ProjectAPI.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDTO>().ReverseMap();
            CreateMap<Discount, CreateDiscountDTO>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDTO>().ReverseMap();
            CreateMap<Discount, GetDiscountDTO>().ReverseMap();
        }
    }
}

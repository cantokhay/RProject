using AutoMapper;
using Project.Data.Entities;
using Project.DTO.BookingDTO;

namespace ProjectAPI.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDTO>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();
            CreateMap<Booking, GetBookingDTO>().ReverseMap();
        }
    }
}

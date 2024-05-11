using AutoMapper;
using Project.Data.Entities;
using Project.DTO.ContactDTO;

namespace ProjectAPI.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, GetContactDTO>().ReverseMap();
        }
    }
}

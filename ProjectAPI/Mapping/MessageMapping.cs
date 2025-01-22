using AutoMapper;
using Project.Data.Entities;
using Project.DTO.MessageDTO;

namespace ProjectAPI.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, GetMessageDTO>().ReverseMap();
        }
    }
}

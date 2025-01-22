using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.MessageDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var messageList = _messageService.TGetAll();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(messageList));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            _messageService.TAdd(message);
            return Ok("Mesaj Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _messageService.TGetById(id);
            _messageService.TDelete(message);
            return Ok("Mesaj Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var message = _mapper.Map<Message>(updateMessageDTO);
            _messageService.TUpdate(message);
            return Ok("Mesaj Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _messageService.TGetById(id);
            return Ok(_mapper.Map<GetMessageDTO>(message));
        }
    }
}

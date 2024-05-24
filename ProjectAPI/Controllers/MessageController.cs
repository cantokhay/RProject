using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DTO.MessageDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var messageList = _messageService.TGetAll();
            return Ok(messageList);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            _messageService.TAdd(new Message()
            {
                MessageFullName = createMessageDTO.MessageFullName,
                MessageEmail = createMessageDTO.MessageEmail,
                MessageSubject = createMessageDTO.MessageSubject,
                MessageContent = createMessageDTO.MessageContent,
                MessagePhone = createMessageDTO.MessagePhone,
                MessageDate = DateTime.Now,
                MessageStatus = false
            });
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
            _messageService.TUpdate(new Message()
            {
                MessageId = updateMessageDTO.MessageId,
                MessageFullName = updateMessageDTO.MessageFullName,
                MessageEmail = updateMessageDTO.MessageEmail,
                MessageSubject = updateMessageDTO.MessageSubject,
                MessageContent = updateMessageDTO.MessageContent,
                MessagePhone = updateMessageDTO.MessagePhone,
                MessageDate = updateMessageDTO.MessageDate,
                MessageStatus = false
            });
            return Ok("Mesaj Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _messageService.TGetById(id);
            return Ok(message);
        }
    }
}

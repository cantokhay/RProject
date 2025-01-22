using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.ContactDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contactList = _contactService.TGetAll();
            return Ok(_mapper.Map<List<ResultContactDTO>>(contactList));
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            var contact = _mapper.Map<Contact>(createContactDTO);
            _contactService.TAdd(contact);
            return Ok("İletişim Bilgisi Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetById(id);
            _contactService.TDelete(contact);
            return Ok("İletişim Bilgisi Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            var contact = _mapper.Map<Contact>(updateContactDTO);
            _contactService.TUpdate(contact);
            return Ok("İletişim Bilgisi Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDTO>(contact));
        }
    }
}

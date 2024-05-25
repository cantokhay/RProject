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
            return Ok(contactList);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            _contactService.TAdd(new Contact()
            {
                ContactLocation = createContactDTO.ContactLocation,
                ContactPhone = createContactDTO.ContactPhone,
                ContactEmail = createContactDTO.ContactEmail,
                FooterDescription = createContactDTO.FooterDescription,
                FooterTitle = createContactDTO.FooterTitle,
                OpenDays = createContactDTO.OpenDays,
                OpenDaysDescription = createContactDTO.OpenDaysDescription,
                OpenHours = createContactDTO.OpenHours,
				CreatedDate = DateTime.Now,
				DataStatus = DataStatus.Active
			});
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
            _contactService.TUpdate(new Contact()
            {
                ContactId = updateContactDTO.ContactId,
                ContactLocation = updateContactDTO.ContactLocation,
                ContactPhone = updateContactDTO.ContactPhone,
                ContactEmail = updateContactDTO.ContactEmail,
                FooterDescription = updateContactDTO.FooterDescription,
				FooterTitle = updateContactDTO.FooterTitle,
				OpenDays = updateContactDTO.OpenDays,
				OpenDaysDescription = updateContactDTO.OpenDaysDescription,
				OpenHours = updateContactDTO.OpenHours,
				CreatedDate = updateContactDTO.CreatedDate,
				DataStatus = DataStatus.Modified,
				ModifiedDate = DateTime.Now
			});
            return Ok("İletişim Bilgisi Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.TGetById(id);
            return Ok(contact);
        }
    }
}

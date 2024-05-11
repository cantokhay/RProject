using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DTO.AboutDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var aboutList = _aboutService.TGetAll();
            return Ok(aboutList);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            _aboutService.TAdd(new About()
            {
                AboutTitle = createAboutDTO.AboutTitle,
                AboutDescription = createAboutDTO.AboutDescription,
                AboutImageURL = createAboutDTO.AboutImageURL
            });
            return Ok("Hakkında Kısmı Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _aboutService.TGetById(id);
            _aboutService.TDelete(about);
            return Ok("Hakkında Alanı Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            _aboutService.TUpdate(new About()
            {
                AboutId = updateAboutDTO.AboutId,
                AboutTitle = updateAboutDTO.AboutTitle,
                AboutDescription = updateAboutDTO.AboutDescription,
                AboutImageURL = updateAboutDTO.AboutImageURL
            });
            return Ok("Hakkında Alanı Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetAboutById(int id)
        {
            var about = _aboutService.TGetById(id);
            return Ok(about);
        }
    }
}

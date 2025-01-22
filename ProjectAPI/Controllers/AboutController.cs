using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
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
            return Ok(_mapper.Map<List<ResultAboutDTO>>(aboutList));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            var about = _mapper.Map<About>(createAboutDTO);
            _aboutService.TAdd(about);
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
            var about = _mapper.Map<About>(updateAboutDTO);
            _aboutService.TUpdate(about);
            return Ok("Hakkında Alanı Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetAboutById(int id)
        {
            var about = _aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDTO>(about));
        }
    }
}

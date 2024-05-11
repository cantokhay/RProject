using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DTO.SocialMediaDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMediaList = _socialMediaService.TGetAll();
            return Ok(socialMediaList);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                SocialMediaTitle = createSocialMediaDTO.SocialMediaTitle,
                SocialMediaURL = createSocialMediaDTO.SocialMediaURL,
                SocialMediaIcon = createSocialMediaDTO.SocialMediaIcon
            });
            return Ok("Sosyal Medya Hesabı Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(socialMedia);
            return Ok("Sosyal Medya Hesabı Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaId = updateSocialMediaDTO.SocialMediaId,
                SocialMediaTitle = updateSocialMediaDTO.SocialMediaTitle,
                SocialMediaURL = updateSocialMediaDTO.SocialMediaURL,
                SocialMediaIcon = updateSocialMediaDTO.SocialMediaIcon
            });
            return Ok("Sosyal Medya Hesabı Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMediaById(int id)
        {
            var socialMedia = _socialMediaService.TGetById(id);
            return Ok(socialMedia);
        }
    }
}

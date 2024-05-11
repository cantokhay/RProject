using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DTO.FeatureDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var featureList = _featureService.TGetAll();
            return Ok(featureList);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            _featureService.TAdd(new Feature()
            {
                FeatureTitle1 = createFeatureDTO.FeatureTitle1,
                FeatureDescription1 = createFeatureDTO.FeatureDescription1,
                FeatureTitle2 = createFeatureDTO.FeatureTitle2,
                FeatureDescription2 = createFeatureDTO.FeatureDescription2,
                FeatureTitle3 = createFeatureDTO.FeatureTitle3,
                FeatureDescription3 = createFeatureDTO.FeatureDescription3
            });
            return Ok("Özellik Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            _featureService.TDelete(feature);
            return Ok("Özellik Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureId = updateFeatureDTO.FeatureId,
                FeatureTitle1 = updateFeatureDTO.FeatureTitle1,
                FeatureDescription1 = updateFeatureDTO.FeatureDescription1,
                FeatureTitle2 = updateFeatureDTO.FeatureTitle2,
                FeatureDescription2 = updateFeatureDTO.FeatureDescription2,
                FeatureTitle3 = updateFeatureDTO.FeatureTitle3,
                FeatureDescription3 = updateFeatureDTO.FeatureDescription3
            });
            return Ok("Özellik Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeatureById(int id)
        {
            var feature = _featureService.TGetById(id);
            return Ok(feature);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.SliderDTO;

namespace ProjectAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _sliderService;
		private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SliderList()
		{
			var sliderList = _sliderService.TGetAll();
			return Ok(_mapper.Map<List<ResultSliderDTO>>(sliderList));
		}

		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDTO createSliderDTO)
		{
			var slider = _mapper.Map<Slider>(createSliderDTO);
            _sliderService.TAdd(slider);
			return Ok("Özellik Eklendi!");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var slider = _sliderService.TGetById(id);
			_sliderService.TDelete(slider);
			return Ok("Özellik Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDTO updateSliderDTO)
		{
			var slider = _mapper.Map<Slider>(updateSliderDTO);
            _sliderService.TUpdate(slider);
			return Ok("Özellik Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetSliderById(int id)
		{
			var slider = _sliderService.TGetById(id);
			return Ok(_mapper.Map<GetSliderDTO>(slider));
		}
	}
}

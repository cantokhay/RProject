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
			var sliderList = _mapper.Map<List<ResultSliderDTO>>(_sliderService.TGetAll());
			return Ok(sliderList);
		}

		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDTO createSliderDTO)
		{
			_sliderService.TAdd(new Slider()
			{
				SliderTitle1 = createSliderDTO.SliderTitle1,
				SliderDescription1 = createSliderDTO.SliderDescription1,
				SliderTitle2 = createSliderDTO.SliderTitle2,
				SliderDescription2 = createSliderDTO.SliderDescription2,
				SliderTitle3 = createSliderDTO.SliderTitle3,
				SliderDescription3 = createSliderDTO.SliderDescription3,
				CreatedDate = DateTime.Now,
				DataStatus = DataStatus.Active
			});
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
			_sliderService.TUpdate(new Slider()
			{
				SliderId = updateSliderDTO.SliderId,
				SliderTitle1 = updateSliderDTO.SliderTitle1,
				SliderDescription1 = updateSliderDTO.SliderDescription1,
				SliderTitle2 = updateSliderDTO.SliderTitle2,
				SliderDescription2 = updateSliderDTO.SliderDescription2,
				SliderTitle3 = updateSliderDTO.SliderTitle3,
				SliderDescription3 = updateSliderDTO.SliderDescription3,
				CreatedDate = updateSliderDTO.CreatedDate,
				DataStatus = DataStatus.Modified,
				ModifiedDate = DateTime.Now
			});
			return Ok("Özellik Güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetSliderById(int id)
		{
			var slider = _sliderService.TGetById(id);
			return Ok(slider);
		}
	}
}

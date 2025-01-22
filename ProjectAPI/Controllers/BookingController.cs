using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.BookingDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var bookingList = _bookingService.TGetAll();
            return Ok(_mapper.Map<List<ResultBookingDTO>>(bookingList));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO createBookingDTO)
        {
            var booking = _mapper.Map<Booking>(createBookingDTO);
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _bookingService.TGetById(id);
            _bookingService.TDelete(booking);
            return Ok("Rezervasyon Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDTO updateBookingDTO)
        {
            var booking = _mapper.Map<Booking>(updateBookingDTO);
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = _bookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDTO>(booking));
        }

        [HttpGet("STATUS_APRROVE/{id}")]
        public IActionResult BookingStatusChangeAprooved(int id)
        {
            _bookingService.TBookingStatusChangeAprooved(id);
            return Ok("Rezervasyon Onaylandı!");
        }

        [HttpGet("STATUS_CANCEL/{id}")]
        public IActionResult BookingStatusChangeCancelled(int id)
        {
            _bookingService.TBookingStatusChangeCancelled(id);
            return Ok("Rezervasyon İptal Edildi!");
        }
    }
}

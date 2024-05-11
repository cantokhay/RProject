using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
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
            return Ok(bookingList);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO createBookingDTO)
        {
            _bookingService.TAdd(new Booking()
            {
                BookingDate = createBookingDTO.BookingDate,
                BookingName = createBookingDTO.BookingName,
                BookingEmail = createBookingDTO.BookingEmail,
                BookingPhone = createBookingDTO.BookingPhone,
                PersonCount = createBookingDTO.PersonCount
            });
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
            _bookingService.TUpdate(new Booking()
            {
                BookingId = updateBookingDTO.BookingId,
                BookingDate = updateBookingDTO.BookingDate,
                BookingName = updateBookingDTO.BookingName,
                BookingEmail = updateBookingDTO.BookingEmail,
                BookingPhone = updateBookingDTO.BookingPhone,
                PersonCount = updateBookingDTO.PersonCount
            });
            return Ok("Rezervasyon Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = _bookingService.TGetById(id);
            return Ok(booking);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DTO.NotificationDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var notificationList = _notificationService.TGetAll();
            return Ok(_mapper.Map<List<ResultNotificationDTO>>(notificationList));
        }

        [HttpGet("NOTIFICATION_COUNT_BY_STATUS")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var notificationCount = _notificationService.TNotificationCountByStatusFalse();
            return Ok(notificationCount);
        }

        [HttpGet("NOTIFICATION_LIST_BY_STATUS")]
        public IActionResult NotificationListByStatusFalse()
        {
            var notificationList = _notificationService.TGetAllNotificationByFalse();
            return Ok(notificationList);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDTO);
            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncellendi!");
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO createNotificationDto)
        {
            Notification notification = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarıyla yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var notification = _notificationService.TGetById(id);
            _notificationService.TDelete(notification);
            return Ok("Bildirim Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var notification = _notificationService.TGetById(id);
            return Ok(_mapper.Map<GetNotificationDTO>(notification));
        }

        [HttpGet("CHANGE_STATUS_FALSE/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Bildirim Durumu Okunmadı Yapıldı");
        }

        [HttpGet("CHANGE_STATUS_TRUE/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Bildirim Durumu Okundu Yapıldı");
        }
    }
}

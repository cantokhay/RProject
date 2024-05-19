using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DTO.NotificationDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var notificationList = _notificationService.TGetAll();
            return Ok(notificationList);
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
            Notification notification = new Notification()
            {
                NotificationId = updateNotificationDTO.NotificationId,
                Message = updateNotificationDTO.Message,
                NotificationStatus = updateNotificationDTO.NotificationStatus,
                Type = updateNotificationDTO.Type,
                Icon = updateNotificationDTO.Icon,
                NotificationDate = updateNotificationDTO.NotificationDate
            };

            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncellendi!");
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Message = createNotificationDto.Message,
                Icon = createNotificationDto.Icon,
                NotificationStatus = false,
                Type = createNotificationDto.Type,
                NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarıyla yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
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

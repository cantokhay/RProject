using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;

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
    }
}

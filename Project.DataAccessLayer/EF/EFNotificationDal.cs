using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EFNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.NotificationStatus == NotificationStatus.Unread && x.DataStatus != DataStatus.Deleted).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.NotificationStatus == NotificationStatus.Unread && x.DataStatus != DataStatus.Deleted).Count();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using var context = new SignalRContext();
            var notification = context.Notifications.Find(id);
            notification.NotificationStatus = NotificationStatus.Unread;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context = new SignalRContext();
            var notification = context.Notifications.Find(id);
            notification.NotificationStatus = NotificationStatus.Read;
            context.SaveChanges();
        }
    }
}

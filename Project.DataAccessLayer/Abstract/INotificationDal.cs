using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNotificationByFalse();
        void NotificationStatusChangeToFalse(int id);
        void NotificationStatusChangeToTrue(int id);
    }
}

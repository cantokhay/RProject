using Project.Data.Entities;

namespace Project.Business.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusChangeAprooved(int id);
        void TBookingStatusChangeCancelled(int id);
    }
}

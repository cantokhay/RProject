using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusChangeAprooved(int id);
        void BookingStatusChangeCancelled(int id);
    }
}

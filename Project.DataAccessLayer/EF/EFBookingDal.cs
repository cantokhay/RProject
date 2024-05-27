using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EFBookingDal(SignalRContext context) : base(context)
        {
        }

        public void BookingStatusChangeAprooved(int id)
        {
            using var context = new SignalRContext();
            var bookingToChange = context.Bookings.Find(id);
            bookingToChange.BookingStatus = BookingStatus.Approved;
            context.SaveChanges();
        }

        public void BookingStatusChangeCancelled(int id)
        {
            using var context = new SignalRContext();
            var bookingToChange = context.Bookings.Find(id);
            bookingToChange.BookingStatus = BookingStatus.Rejected;
            context.SaveChanges();
        }
    }
}

using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusChangeAprooved(int id)
        {
            _bookingDal.BookingStatusChangeAprooved(id);
        }

        public void TBookingStatusChangeCancelled(int id)
        {
            _bookingDal.BookingStatusChangeCancelled(id);
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_bookingDal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}

using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFSliderDal : GenericRepository<Slider>, ISliderDal
    {
        public EFSliderDal(SignalRContext context) : base(context)
        {
        }
    }
}

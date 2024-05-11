using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EFTestimonialDal(SignalRContext context) : base(context)
        {
        }
    }
}

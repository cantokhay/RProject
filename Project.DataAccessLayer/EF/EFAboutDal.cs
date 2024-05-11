using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(SignalRContext context) : base(context)
        {
        }
    }
}

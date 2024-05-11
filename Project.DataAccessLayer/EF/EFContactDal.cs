using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
        public EFContactDal(SignalRContext context) : base(context)
        {
        }
    }
}

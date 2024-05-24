using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EFMessageDal(SignalRContext context) : base(context)
        {
        }
    }
}

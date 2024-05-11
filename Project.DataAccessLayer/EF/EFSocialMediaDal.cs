using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EFSocialMediaDal(SignalRContext context) : base(context)
        {
        }
    }
}

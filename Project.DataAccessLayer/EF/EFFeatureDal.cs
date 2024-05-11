using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EFFeatureDal(SignalRContext context) : base(context)
        {
        }
    }
}

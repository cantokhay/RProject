using Project.Data.Entities;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DataAccess.Repositories;

namespace Project.DataAccess.EF
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(c => c.DataStatus != Data.Enums.DataStatus.Deleted).Count();
		}

		public int GetCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(c => c.DataStatus != Data.Enums.DataStatus.Deleted).Count();
		}

		public int PassiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(c => c.DataStatus == Data.Enums.DataStatus.Deleted).Count();
		}
	}
}

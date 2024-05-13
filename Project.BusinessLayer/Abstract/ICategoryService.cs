using Project.Data.Entities;
namespace Project.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
		public int TGetCategoryCount();
		int TActiveCategoryCount();
		int TPassiveCategoryCount();

	}
}

using Project.Data.Entities;
namespace Project.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
		int TGetCategoryCount();
		int TActiveCategoryCount();
		int TPassiveCategoryCount();

	}
}

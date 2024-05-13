using Project.Data.Entities;

namespace Project.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        int GetCategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
    }
}

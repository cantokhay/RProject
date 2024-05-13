using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public int TGetCategoryCount()
		{
			return _categoryDal.GetCategoryCount();
		}

		public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

		public int TActiveCategoryCount()
		{
			return _categoryDal.ActiveCategoryCount();
		}

		public int TPassiveCategoryCount()
		{
			return _categoryDal.PassiveCategoryCount();
		}
	}
}

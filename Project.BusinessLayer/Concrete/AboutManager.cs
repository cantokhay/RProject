using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
			_aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Deleted;
			_aboutDal.Delete(entity);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void TUpdate(About entity)
        {
			_aboutDal.Update(entity);
        }
    }
}

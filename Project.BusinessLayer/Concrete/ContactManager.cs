using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Active;
            _contactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Deleted;
			_contactDal.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void TUpdate(Contact entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Modified;
            _contactDal.Update(entity);
        }
    }
}

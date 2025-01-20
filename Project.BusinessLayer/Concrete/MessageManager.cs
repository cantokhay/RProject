using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Active;
            _messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_messageDal.Delete(entity);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TUpdate(Message entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = DataStatus.Modified;
            _messageDal.Update(entity);
        }
    }
}

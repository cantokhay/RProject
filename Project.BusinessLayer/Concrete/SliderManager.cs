using Project.Business.Abstract;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.DataAccess.Abstract;

namespace Project.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
            entity.DeletedDate = DateTime.Now;
			entity.DataStatus = DataStatus.Deleted;
			_sliderDal.Delete(entity);
        }

        public List<Slider> TGetAll()
        {
            return _sliderDal.GetAll().Where(x => x.DataStatus != DataStatus.Deleted).ToList();
		}

        public Slider TGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}

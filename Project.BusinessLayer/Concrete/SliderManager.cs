using Project.Business.Abstract;
using Project.Data.Entities;
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
            throw new NotImplementedException();
        }

        public void TDelete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public List<Slider> TGetAll()
        {
            return _sliderDal.GetAll();
        }

        public Slider TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}

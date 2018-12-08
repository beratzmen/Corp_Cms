using CMS.Dal.Abstract.SliderDal;
using CMS.Interfaces.Slider;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.Slider
{
    public class SliderManager : ISliderService
    {
        ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }
        public void Add(Entities.Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _sliderDal.Delete(Id);
        }

        public Entities.Slider Get(int Id)
        {
            return _sliderDal.Get(Id);
        }

        public List<Entities.Slider> GetAll()
        {
            return _sliderDal.GetAll();
        }

        public void Update(Entities.Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}

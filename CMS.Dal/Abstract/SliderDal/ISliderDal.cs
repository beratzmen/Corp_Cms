using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.SliderDal
{
    public interface ISliderDal
    {
        List<Slider> GetAll();
        Slider Get(int Id);
        void Add(Slider entity);
        void Delete(int Id);
        void Update(Slider entity);
    }
}

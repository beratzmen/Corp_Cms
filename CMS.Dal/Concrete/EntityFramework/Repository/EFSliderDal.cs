using CMS.Dal.Abstract.SliderDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFSliderDal : ISliderDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Slider entity)
        {
            context.Slider.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Slider.Remove(context.Slider.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Slider Get(int Id)
        {
            return context.Slider.FirstOrDefault(x => x.Id == Id);
        }

        public List<Slider> GetAll()
        {
            return context.Slider.ToList();
        }

        public void Update(Slider entity)
        {
            Slider sliderToUpdate = context.Slider.FirstOrDefault(x => x.Id == entity.Id);
            sliderToUpdate.Image = entity.Image;
            sliderToUpdate.Text = entity.Text;
            sliderToUpdate.TextEN = entity.TextEN;
            context.SaveChanges();
        }
    }
}

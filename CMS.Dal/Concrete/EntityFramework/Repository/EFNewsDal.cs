using CMS.Dal.Abstract.NewsDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFNewsDal : INewsDal
    {
        private CmsContext context = new CmsContext();
        public void Add(News entity)
        {
            context.News.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.News.Remove(context.News.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public News Get(int Id)
        {
            return context.News.FirstOrDefault(x => x.Id == Id);
        }

        public List<News> GetAll()
        {
            return context.News.ToList();
        }

        

        public void Update(News entity)
        {
            News newsToUpdate = context.News.FirstOrDefault(x => x.Id == entity.Id);
            newsToUpdate.Title = entity.Title;
            newsToUpdate.TitleEN = entity.TitleEN;
            newsToUpdate.ContentText = entity.ContentText;
            newsToUpdate.ContentTextEN = entity.ContentTextEN;
            newsToUpdate.Date = entity.Date;
            newsToUpdate.Image = entity.Image;            
            context.SaveChanges();
        }
    }
}

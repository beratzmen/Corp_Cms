using CMS.Dal.Abstract.PagesDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFPagesDal : IPagesDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Pages entity)
        {
            context.Pages.Add(entity);
            context.SaveChanges();
        }

        

        public void Delete(int Id)
        {
            context.Pages.Remove(context.Pages.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Pages Get(int Id)
        {
            return context.Pages.FirstOrDefault(x => x.Id == Id);
        }

        public List<Pages> GetAll()
        {
            return context.Pages.ToList();
        }

        public Pages GetElementByName(string pageName)
        {
            Pages search = context.Pages.FirstOrDefault(x => x.Name == pageName);
            return search;
            //var query = from c in ctx.Pages

            //            where c.Name == pageName

            //            select c;
            //return query;
            //List<Pages> sonuc3 = (from d in db.Pages where d.Name.Contains(pageName) select d).ToList();
        }

        public void Update(Pages entity)
        {
            Pages pagesToUpdate = context.Pages.FirstOrDefault(x => x.Id == entity.Id);
            pagesToUpdate.Name = entity.Name;
            pagesToUpdate.Title = entity.Title;
            pagesToUpdate.TitleEN = entity.TitleEN;
            pagesToUpdate.ContentText = entity.ContentText;
            pagesToUpdate.ContentTextEN = entity.ContentTextEN;
            context.SaveChanges();
        }
    }
}

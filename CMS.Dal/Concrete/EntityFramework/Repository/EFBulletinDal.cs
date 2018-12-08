using CMS.Dal.Abstract.BulletinDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public  class EFBulletinDal:IBulletinDal
    {
        private CmsContext context = new CmsContext();

        public void Add(Bulletin entity)
        {
            context.Bulletin.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Bulletin.Remove(context.Bulletin.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Bulletin Get(int Id)
        {
            return context.Bulletin.FirstOrDefault(x => x.Id == Id);
        }

        public List<Bulletin> GetAll()
        {
            return context.Bulletin.ToList();
        }

        public void Update(Bulletin entity)
        {
            Bulletin bulletinToUpdate = context.Bulletin.FirstOrDefault(x => x.Id == entity.Id);
            bulletinToUpdate.Title = entity.Title;
            bulletinToUpdate.ContentText = entity.ContentText;
            bulletinToUpdate.Date = entity.Date;
            context.SaveChanges();
        }
    }
}

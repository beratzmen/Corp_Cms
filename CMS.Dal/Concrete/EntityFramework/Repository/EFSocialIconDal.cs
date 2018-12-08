using CMS.Dal.Abstract.SocialIconDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFSocialIconDal : ISocialIconDal
    {
        private CmsContext context = new CmsContext();
        public void Add(SocialIcon entity)
        {
            context.SocialIcon.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.SocialIcon.Remove(context.SocialIcon.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public SocialIcon Get(int Id)
        {
            return context.SocialIcon.FirstOrDefault(x => x.Id == Id);
        }

        public List<SocialIcon> GetAll()
        {
            return context.SocialIcon.ToList();
        }

        public SocialIcon GetElementByName(string productName)
        {
            SocialIcon search = context.SocialIcon.FirstOrDefault(x => x.Name == productName);
            return search;
        }

        public void Update(SocialIcon entity)
        {
            SocialIcon socialToUpdate = context.SocialIcon.FirstOrDefault(x => x.Id == entity.Id);
            socialToUpdate.Link = entity.Link;
            context.SaveChanges();
        }
    }
}

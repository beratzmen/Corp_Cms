using CMS.Dal.Abstract.NewsMemberDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFBulletinMemberDal : IBulletinMemberDal
    {
        private CmsContext context = new CmsContext();
        public void Add(BulletinMember entity)
        {
            context.BulletinMember.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.BulletinMember.Remove(context.BulletinMember.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public BulletinMember Get(int Id)
        {
            return context.BulletinMember.FirstOrDefault(x => x.Id == Id);
        }

        public List<BulletinMember> GetAll()
        {
            return context.BulletinMember.ToList();
        }

        public void Update(BulletinMember entity)
        {
            BulletinMember newsMemberToUpdate = context.BulletinMember.FirstOrDefault(x => x.Id == entity.Id);
            newsMemberToUpdate.Counter += 1;
            context.SaveChanges();
        }
    }
}

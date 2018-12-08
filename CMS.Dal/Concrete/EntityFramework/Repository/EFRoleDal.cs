using CMS.Dal.Abstract.RolDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFRoleDal : IRoleDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Role entity)
        {
            context.Role.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Role.Remove(context.Role.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Role Get(int Id)
        {
            return context.Role.FirstOrDefault(x => x.Id == Id);
        }

        public List<Role> GetAll()
        {
            return context.Role.ToList();
        }

        public void Update(Role entity)
        {
            Role rolToUpdate = context.Role.FirstOrDefault(x => x.Id == entity.Id);
            rolToUpdate.RoleName = entity.RoleName;
           
            context.SaveChanges();
        }
    }
}

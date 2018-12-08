
using CMS.Dal.Abstract.UserDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{

    public class EFUserDal : IUserDal
    {
        private CmsContext context = new CmsContext();
        public void Add(User entity)
        {
            context.User.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.User.Remove(context.User.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public User Get(int Id)
        {
            return context.User.FirstOrDefault(x => x.Id == Id);
        }

        public List<User> GetAll()
        {
            return context.User.ToList();
        }

        public void Update(User entity)
        {
            User userToUpdate = context.User.FirstOrDefault(x => x.Id == entity.Id);
            userToUpdate.Name = entity.Name;
            userToUpdate.SurName = entity.SurName;
            userToUpdate.EMail = entity.EMail;
            userToUpdate.Password = entity.Password;
            userToUpdate.RoleID = entity.RoleID;
            context.SaveChanges();
        }

        public User userLogin(string EMail, string sifre)
        {
            return context.User.FirstOrDefault(p => p.EMail == EMail && p.Password == sifre);
            //return context.User.Where(x => x.EMail == EMail && x.Password == sifre).SingleOrDefault();
        }
    }
}

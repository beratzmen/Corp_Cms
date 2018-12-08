using CMS.Dal.Abstract.ContactDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFContactDal : IContactDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Contact entity)
        {
            context.Contact.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Contact.Remove(context.Contact.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Contact Get(int Id)
        {
            return context.Contact.FirstOrDefault(x => x.Id == Id);
        }

        public List<Contact> GetAll()
        {
            return context.Contact.ToList();
        }

        public void Update(Contact entity)
        {
            Contact contactToUpdate = context.Contact.FirstOrDefault(x => x.Id == entity.Id);
            contactToUpdate.Name = entity.Name;
            contactToUpdate.Phone = entity.Phone;
            contactToUpdate.Message = entity.Message;
            contactToUpdate.EMail = entity.EMail;
            context.SaveChanges();
        }
    }
}

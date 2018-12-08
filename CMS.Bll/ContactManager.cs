using CMS.Dal.Abstract.ContactDal;
using CMS.Interfaces.Contact;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.Contact
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void Add(Entities.Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _contactDal.Delete(Id);
        }

        public Entities.Contact Get(int Id)
        {
            return _contactDal.Get(Id);
        }

        public List<Entities.Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public void Update(Entities.Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}

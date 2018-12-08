using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.ContactDal
{
    public interface IContactDal
    {
        List<Contact> GetAll();
        Contact Get(int Id);
        void Add(Contact entity);
        void Delete(int Id);
        void Update(Contact entity);
    }
}

using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.RolDal
{
    public interface IRoleDal
    {
        List<Role> GetAll();
        Role Get(int Id);
        void Add(Role entity);
        void Delete(int Id);
        void Update(Role entity);
    }
}

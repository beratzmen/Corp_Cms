using CMS.Dal.Abstract.RolDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public void Add(Role entity)
        {
            _roleDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _roleDal.Delete(Id);
        }

        public Role Get(int Id)
        {
            return _roleDal.Get(Id);
        }

        public List<Role> GetAll()
        {
            return _roleDal.GetAll();
        }

        public void Update(Role entity)
        {
            _roleDal.Update(entity);
        }
    }
}

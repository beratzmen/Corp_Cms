using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract
{
    public interface IMenuDal
    {
        List<Menu> GetAll();
        Menu Get(int menuId);
        void Add(Menu menu);
        void Delete(int menuId);
        void Update(Menu menu);
    }
}

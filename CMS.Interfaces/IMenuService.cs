using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Interfaces
{
    public interface IMenuService
    {

        List<Menu> GetAll();

        Menu Get(int menuId);

        void Add(Menu menu);

        void Delete(int menuId);

        void Update(Menu menu);
    }
}

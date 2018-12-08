using CMS.Dal.Abstract;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFMenuDal : IMenuDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Menu menu)
        {
            if (menu.ParentMenuID == 0 && menu.DisplayOrder == null)
            {
                menu.DisplayOrder = 1 + (context.Menu.Where(x => x.ParentMenuID == 0).Count());
            }
            else if (menu.ParentMenuID != 0 && menu.DisplayOrder == null)
            {
                menu.DisplayOrder = 1 + (context.Menu.Where(x=>x.ParentMenuID!=0).Count());
            }
            context.Menu.Add(menu);
            context.SaveChanges();
        }

        public void Delete(int menuId)
        {
            context.Menu.Remove(context.Menu.FirstOrDefault(x => x.Id == menuId));
            context.SaveChanges();
        }

        public Menu Get(int menuId)
        {
            return context.Menu.FirstOrDefault(x => x.Id == menuId);
        }

        public List<Menu> GetAll()
        {
            return context.Menu.ToList();
        }

        public void Update(Menu menu)
        {
            Menu menuToUpdate = context.Menu.FirstOrDefault(x => x.Id == menu.Id);
            menuToUpdate.Name = menu.Name;
            menuToUpdate.Link = menu.Link;
            menuToUpdate.ParentMenuID = menu.ParentMenuID;
            menuToUpdate.DisplayOrder = menu.DisplayOrder;
            menuToUpdate.NameENG = menu.NameENG;
            context.SaveChanges();
        }
    }
}

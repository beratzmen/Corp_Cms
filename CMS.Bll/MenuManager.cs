using CMS.Dal.Abstract;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class MenuManager : IMenuService
    {
        IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public void Add(Entities.Menu entity)
        {

            _menuDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _menuDal.Delete(Id);
        }

        public Entities.Menu Get(int Id)
        {
            return _menuDal.Get(Id);
        }

        public List<Entities.Menu> GetAll()
        {
            return _menuDal.GetAll();
        }

        public void Update(Entities.Menu entity)
        {
            _menuDal.Update(entity);
        }
    }
}
